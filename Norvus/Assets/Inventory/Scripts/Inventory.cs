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
					AddItem(item);
					break;
				}
            }
        }

		public void AddItem(IItem item)
		{
			if(item.itemAmount <= 0)
			{
				item.itemAmount = 1;
			}

			if (!itemObjects.Contains(item.itemObject) || !item.itemObject.canStack){
				AddNewItemSlot(item);
			}
			else if(itemObjects.Contains(item.itemObject) && item.itemObject.canStack)
			{
                for (int i = 0; i < items.Count; i++)
                {
					if (items[i].itemObject == item.itemObject)
					{
						items[i].itemAmount += item.itemAmount;
						itemSlots[i].GetComponent<ItemSlot>().item = items[i];
						itemSlots[i].GetComponent<ItemSlot>().UpdateItem(); 
					}
                }
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
								newWeaponItemSlot.GetComponent<ItemSlot>().item = itemToAdd;

								itemSlots.Add(newWeaponItemSlot);
								itemObjects.Add(itemToAdd.itemObject);
								items.Add(itemToAdd);
							}
							break;
						case EItemType.consumable:
							if (itemToAdd.itemObject.consumablesType == inventoryTabs[i].consumablesType)
							{
								GameObject newConsumableItemSlot = Instantiate(basicItemSlot);
								newConsumableItemSlot.transform.SetParent(inventoryTabs[i].grid.transform);
								newConsumableItemSlot.transform.localScale = Vector3.one;
								newConsumableItemSlot.GetComponent<ItemSlot>().item = itemToAdd;

								itemSlots.Add(newConsumableItemSlot);
								itemObjects.Add(itemToAdd.itemObject);
								items.Add(itemToAdd);
							}
							break;
						case EItemType.readable:
							if (itemToAdd.itemObject.readableType == inventoryTabs[i].readableType)
							{
								GameObject newReadableItemSlot = Instantiate(basicItemSlot);
								newReadableItemSlot.transform.SetParent(inventoryTabs[i].grid.transform);
								newReadableItemSlot.transform.localScale = Vector3.one;
								newReadableItemSlot.GetComponent<ItemSlot>().item = itemToAdd;

								itemSlots.Add(newReadableItemSlot);
								itemObjects.Add(itemToAdd.itemObject);
								items.Add(itemToAdd);
							}
							break;
						case EItemType.keys:
							GameObject newKeyItemSlot = Instantiate(basicItemSlot);
							newKeyItemSlot.transform.SetParent(inventoryTabs[i].grid.transform);
							newKeyItemSlot.transform.localScale = Vector3.one;
							newKeyItemSlot.GetComponent<ItemSlot>().item = itemToAdd;

							itemSlots.Add(newKeyItemSlot);
							itemObjects.Add(itemToAdd.itemObject);
							items.Add(itemToAdd);
							break;
						case EItemType.misc:
							GameObject newMiscItemSlot = Instantiate(basicItemSlot);
							newMiscItemSlot.transform.SetParent(inventoryTabs[i].grid.transform);
							newMiscItemSlot.transform.localScale = Vector3.one;
							newMiscItemSlot.GetComponent<ItemSlot>().item = itemToAdd;

							itemSlots.Add(newMiscItemSlot);
							itemObjects.Add(itemToAdd.itemObject);
							items.Add(itemToAdd);
							break;
						default:
							break;
					}
					break;
				}
			}
        }
	}
}
