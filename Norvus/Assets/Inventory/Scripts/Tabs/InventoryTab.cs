using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Norvus.Inventory.Tabs
{
	public class InventoryTab : MonoBehaviour
	{
		public EItemType itemType;

		[ShowIf("itemType", EItemType.weapon, true)]
		public EWeaponType weaponType;
		[ShowIf("itemType", EItemType.armour, true)]
		public EArmourType armourType;
		[ShowIf("itemType", EItemType.consumable, true)]
		public EConsumablesType consumablesType;
		[ShowIf("itemType", EItemType.readable, true)]
		public EReadableTypes readableType;

		[BoxGroup("UI")]
		public GameObject grid;
		[BoxGroup("UI")]
		public ScrollRect rect;

		[Button]
		public void SetTab()
		{
			rect = GetComponent<ScrollRect>();
			if (grid)
			{
			}
			else
			{
				grid = this.gameObject;
				print("Grid Missing");
			}

			rect.content = grid.GetComponent<RectTransform>();
		}
	}
}
