using Norvus.Equipment;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Norvus.Health
{
	[RequireComponent(typeof(EquipmentManager))]
	public class HealthManager : MonoBehaviour
	{
		[BoxGroup("References")]
		public EquipmentManager equipmentManager;

		[BoxGroup("UI")]
		public Slider healthSlider;

		[BoxGroup("Health")]
		public float maxHealth;
		[BoxGroup("Health")]
		public float currentHealth;

		private void Start()
		{
			equipmentManager = GetComponent<EquipmentManager>();

			currentHealth = maxHealth;
			healthSlider.maxValue = maxHealth; 
			healthSlider.value = currentHealth;
		}

		[Button]
		public void ChangeHealth(float healthChange, bool isDamage)
		{
			if (isDamage)
			{
				float damageTaken = (healthChange - equipmentManager.armourValue) * 0.75f;

				currentHealth -= damageTaken;
				healthSlider.value = currentHealth;
			}
			else
			{
				currentHealth += healthChange;
				healthSlider.value = currentHealth;
			}
		}
	}
}
