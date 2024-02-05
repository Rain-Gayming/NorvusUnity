using Norvus.Characters;
using Norvus.Equipment;
using Norvus.Health;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Norvus.Player
{
	public class PlayerManager : MonoBehaviour
	{
		[BoxGroup("References")]
		public EquipmentManager playerEquipmentManager;
		[BoxGroup("References")]
		public HealthManager playerHealthManager;
		[BoxGroup("References")]
		public PlayerLocomotion playerLocomotion;
		[BoxGroup("References")]
		public AnimationHandler playerAnimationHandler;
		[BoxGroup("References")]
		public PlayerCursorManager playerCursorManager;

		[BoxGroup("Bools")]
		public bool isInteracting;
	}
}
