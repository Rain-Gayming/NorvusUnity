using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Norvus.Inventory
{
	public class ItemSlot : MonoBehaviour
	{
		[BoxGroup("References")]
		public Inventory relatedInventory;

		[BoxGroup("UI")]
		public TMP_Text itemNameText;

		[BoxGroup("Item")]
		public IItem item;

		private void Start()
		{
			UpdateItem();
		}

		public void UpdateItem()
		{
			itemNameText.text = item.itemObject.itemName;
			if(item.itemAmount > 1)
			{
				itemNameText.text = itemNameText.text + " (" + item.itemAmount + ")"; 
			}
		}

		public void UseItem()
		{
			switch (item.itemObject.itemType)
			{
				case EItemType.weapon:
					break;
				case EItemType.armour:
					switch (item.itemObject.armourType)
					{
						case EArmourType.clothing:
							relatedInventory.equipmentManager.clothingItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						case EArmourType.helmet:
							relatedInventory.equipmentManager.helmetItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						case EArmourType.hat:
							relatedInventory.equipmentManager.hatItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						case EArmourType.chest:
							relatedInventory.equipmentManager.chestItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						case EArmourType.mail:
							relatedInventory.equipmentManager.mailItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						case EArmourType.leg:
							relatedInventory.equipmentManager.legItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						case EArmourType.legMail:
							relatedInventory.equipmentManager.legMailItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						case EArmourType.boots:
							relatedInventory.equipmentManager.bootsItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						case EArmourType.gloves:
							relatedInventory.equipmentManager.glovesItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						case EArmourType.gauntlets:
							relatedInventory.equipmentManager.gauntletsItem = item;
							relatedInventory.equipmentManager.UpdateArmourValue();
							break;
						default:
							break;
					}
					break;
				case EItemType.consumable:
					break;
				case EItemType.readable:
					break;
				case EItemType.keys:
					break;
				case EItemType.misc:
					break;
				default:
					break;
			}
		}
	}
}