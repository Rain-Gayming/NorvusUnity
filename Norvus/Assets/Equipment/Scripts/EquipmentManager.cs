using Norvus.Inventory;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Equipment
{
	public class EquipmentManager : MonoBehaviour
	{

		[BoxGroup("Stats")]
		[Range(0.1f, 100)]
		public float fallDamageResistance;
		[BoxGroup("Stats")]
		[Range(1f, 1000)]
		public int armourValue;

		[BoxGroup("Hands")]
		public IItem leftHandItem;
		[BoxGroup("Hands")]
		public IItem rightHandItem;

		[BoxGroup("Armour")]
		public IItem clothingItem;
		[BoxGroup("Armour")]
		public IItem helmetItem;
		[BoxGroup("Armour")]
		public IItem hatItem;
		[BoxGroup("Armour")]
		public IItem chestItem;
		[BoxGroup("Armour")]
		public IItem mailItem;
		[BoxGroup("Armour")]
		public IItem legItem;
		[BoxGroup("Armour")]
		public IItem legMailItem;
		[BoxGroup("Armour")]
		public IItem bootsItem;
		[BoxGroup("Armour")]
		public IItem glovesItem;
		[BoxGroup("Armour")]
		public IItem gauntletsItem;

		public void UpdateArmourValue()
		{
			int val = 0;
			if (clothingItem.itemObject)
			{
				val += clothingItem.itemObject.armourValue;
			}
			if (helmetItem.itemObject)
			{
				val += helmetItem.itemObject.armourValue;
			}
			if (hatItem.itemObject)
			{
				val += hatItem.itemObject.armourValue;
			}
			if (mailItem.itemObject)
			{
				val += mailItem.itemObject.armourValue;
			}
			if (legItem.itemObject)
			{
				val += legItem.itemObject.armourValue;
			}
			if (legMailItem.itemObject)
			{
				val += legMailItem.itemObject.armourValue;
			}
			if (bootsItem.itemObject)
			{
				val += bootsItem.itemObject.armourValue;
			}
			if (glovesItem.itemObject)
			{
				val += glovesItem.itemObject.armourValue;
			}
			if (gauntletsItem.itemObject)
			{
				val += gauntletsItem.itemObject.armourValue;
			}

			armourValue = val;
		}
	}
}