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
		[BoxGroup("UI")]
		public TMP_Text miscValueText;
		[BoxGroup("UI")]
		public TMP_Text classText;

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
			
			if(item.itemObject.itemType == EItemType.weapon)
			{
				miscValueText.text = item.itemObject.damageValue.ToString();
				miscValueText.gameObject.SetActive(true);
			}
			else if (item.itemObject.itemType == EItemType.armour)
			{
				miscValueText.text = item.itemObject.armourValue.ToString();
				miscValueText.gameObject.SetActive(true);
			}
			else
			{
				miscValueText.gameObject.SetActive(false);
			}

			switch (item.itemObject.itemType)
			{
				case EItemType.weapon:
					classText.text = item.itemObject.weaponType.ToString();
					break;
				case EItemType.armour:
					classText.text = item.itemObject.armourType.ToString();
					break;
				case EItemType.consumable:
					classText.text = item.itemObject.consumablesType.ToString();
					break;
				case EItemType.readable:
					classText.text = item.itemObject.readableType.ToString();
					break;
				case EItemType.keys:
					classText.text = item.itemObject.itemType.ToString();
					break;
				case EItemType.misc:
					classText.text = item.itemObject.miscType.ToString();
					break;
				default:
					break;
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