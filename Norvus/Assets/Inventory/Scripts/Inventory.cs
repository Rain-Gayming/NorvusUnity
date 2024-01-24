using Norvus.Inventory.Tabs;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

namespace Norvus.Inventory
{
	public class Inventory : MonoBehaviour
	{
		[BoxGroup("Items")]
		public List<IItem> items;
		[BoxGroup("Items")]
		public List<ItemObject> itemObjects;
		[BoxGroup("Items")]
		public ItemDatabase itemDatabase;

		[BoxGroup("UI")]
		public List<InventoryTab> inventoryTabs;
		[BoxGroup("UI")]
		public List<GameObject> itemSlots;


		[BoxGroup("Item Slots")]
		public GameObject basicItemSlot;
		[BoxGroup("Item Slots")]
		public GameObject weaponItemSlot;
		[BoxGroup("Item Slots")]
		public GameObject armourItemSlot;

		[BoxGroup("Debugging")]
		public TMP_InputField itemTextID;

		private void Start()
		{
			InventoryTab[] tabs = GetComponentsInChildren<InventoryTab>();

            for (int i = 0; i < tabs.Length; i++)
            {
				inventoryTabs.Add(tabs[i]);
            }
        }

		public void DebugAddItem()
		{
            for (int i = 0; i < itemDatabase.itemsInDatabase.Count; i++)
            {
				if (itemDatabase.itemsInDatabase[i].itemName == itemTextID.text)
				{
					IItem item = new IItem();
					item.itemObject = itemDatabase.itemsInDatabase[i];
					items.Add(item);
				}
            }
        }

		public void AddItem(IItem item)
		{
			if(item.itemAmount <= 0)
			{
				item.itemAmount = 1;
			}

			if (!itemObjects.Contains(item.itemObject)){
				AddNewItemSlot(item);
			}
			else
			{

			}
		}

		public void AddNewItemSlot(IItem itemToAdd)
		{
            for (int i = 0; i < inventoryTabs.Count; i++)
            {
				if(itemToAdd.itemObject.itemType == inventoryTabs[i].itemType)
				{
					print("Types are same");
					switch (inventoryTabs[i].itemType)
					{
						case EItemType.weapon:
							if(itemToAdd.itemObject.weaponType == inventoryTabs[i].weaponType)
							{
								GameObject newWeaponItemSlot = Instantiate(weaponItemSlot);
								newWeaponItemSlot.transform.SetParent(inventoryTabs[i].grid.transform);
								newWeaponItemSlot.transform.localScale = Vector3.one;
							}
							break;
						case EItemType.armour:
							if (itemToAdd.itemObject.armourType == inventoryTabs[i].armourType)
							{
								GameObject newArmourItemSlot = Instantiate(armourItemSlot);
								newArmourItemSlot.transform.SetParent(inventoryTabs[i].grid.transform);
								newArmourItemSlot.transform.localScale = Vector3.one;
							}
							break;
						case EItemType.consumable:
							if (itemToAdd.itemObject.consumablesType == inventoryTabs[i].consumablesType)
							{
								GameObject newConsumableItemSlot = Instantiate(basicItemSlot);
								newConsumableItemSlot.transform.SetParent(inventoryTabs[i].grid.transform);
								newConsumableItemSlot.transform.localScale = Vector3.one;
								print(newConsumableItemSlot);
								print("Consumable Types are the same");
							}
							break;
						case EItemType.readable:
							if (itemToAdd.itemObject.readableType == inventoryTabs[i].readableType)
							{
								GameObject newReadableItemSlot = Instantiate(basicItemSlot);
								newReadableItemSlot.transform.SetParent(inventoryTabs[i].grid.transform);
								newReadableItemSlot.transform.localScale = Vector3.one;
							}
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
	}
}
