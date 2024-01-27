using JetBrains.Annotations;
using Norvus.Equipment;
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
		[BoxGroup("Player")]
		public bool isPlayer;
		[BoxGroup("Player")]
		public static Inventory playerInstance;

		[BoxGroup("References")]
		public EquipmentManager equipmentManager;

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

		[BoxGroup("Debugging")]
		public TMP_InputField itemTextID;

		private void Start()
		{
			if (isPlayer)
			{
				playerInstance = this;
			}			
			
			InventoryTab[] tabs = GetComponentsInChildren<InventoryTab>();

            for (int i = 0; i < tabs.Length; i++)
            {
				inventoryTabs.Add(tabs[i]);
            }

			if(items.Count > 0)
			{
                for (int i = 0; i < items.Count; i++)
                {
					AddItem(items[i]);
                }
            }
        }

		public void DebugAddItem()
		{
			string[] itemNameArray = itemTextID.text.Split(',');

			List<string> itemNames = new List<string>();

			for (int i = 0; i < itemNameArray.Length; i++)
            {
				itemNames.Add(itemNameArray[i]);	
            }



			for (int i = 0; i < itemNames.Count; i++)
			{
				if (itemNames[i].StartsWith(' '))
				{
					string[] strings = itemNames[i].Split(' ');

					string newItemName = strings[1];

                    for (int j = 0; j < strings.Length; j++)
                    {
                        if(j > 1)
						{
							newItemName = newItemName + " " + strings[j]; 
						}
                    }

					itemNames.Remove(itemNames[i]);
					itemNames.Add(newItemName);
				}
				for (int d = 0; d < itemDatabase.itemsInDatabase.Count; d++)
				{
					if (itemDatabase.itemsInDatabase[d].itemName == itemNames[i])
					{
						IItem item = new IItem();
						item.itemObject = itemDatabase.itemsInDatabase[d];
						AddItem(item);
					}
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

		public void RemoveItem(IItem itemToRemove)
		{
			if (itemObjects.Contains(itemToRemove.itemObject))
			{
				items[itemObjects.IndexOf(itemToRemove.itemObject)].itemAmount -= itemToRemove.itemAmount;

				Destroy(itemSlots[itemObjects.IndexOf(itemToRemove.itemObject)]);
				itemSlots.RemoveAt(itemObjects.IndexOf(itemToRemove.itemObject));


				if (items[itemObjects.IndexOf(itemToRemove.itemObject)].itemAmount <= 0)
				{
					items.RemoveAt(itemObjects.IndexOf(itemToRemove.itemObject));
					itemObjects.RemoveAt(itemObjects.IndexOf(itemToRemove.itemObject));
				}
			}
		}

		public void AddNewItemSlot(IItem itemToAdd)
		{
            for (int i = 0; i < inventoryTabs.Count; i++)
            {
				if(itemToAdd.itemObject.itemType == inventoryTabs[i].itemType)
				{
					switch (inventoryTabs[i].itemType)
					{
						case EItemType.weapon:
							if (itemToAdd.itemObject.weaponType == inventoryTabs[i].weaponType)
							{
								AddNewSlotUI(inventoryTabs[i].grid.transform, itemToAdd);
							}
							else
							{
								continue;
							}
							break;
						case EItemType.armour:
							if (itemToAdd.itemObject.armourType == inventoryTabs[i].armourType)
							{
								AddNewSlotUI(inventoryTabs[i].grid.transform, itemToAdd);
							}
							else
							{
								continue;
							}
							break;
						case EItemType.consumable:
							if (itemToAdd.itemObject.consumablesType == inventoryTabs[i].consumablesType)
							{
								AddNewSlotUI(inventoryTabs[i].grid.transform, itemToAdd);
							}
							else
							{
								continue;
							}
							break;
						case EItemType.readable:
							if (itemToAdd.itemObject.readableType == inventoryTabs[i].readableType)
							{
								AddNewSlotUI(inventoryTabs[i].grid.transform, itemToAdd);
							}
							else
							{
								continue;
							}
							break;
						case EItemType.keys:
							AddNewSlotUI(inventoryTabs[i].grid.transform, itemToAdd);
							break;
						case EItemType.misc:
							AddNewSlotUI(inventoryTabs[i].grid.transform, itemToAdd);
							break;
						default:
							break;
					}
					break;
				}
			}
        }

		public void AddNewSlotUI(Transform tab, IItem itemToAdd)
		{
			GameObject newItemSlot = Instantiate(basicItemSlot);
			newItemSlot.transform.SetParent(tab);
			newItemSlot.transform.localScale = Vector3.one;
			newItemSlot.GetComponent<ItemSlot>().item = itemToAdd;
			newItemSlot.GetComponent<ItemSlot>().relatedInventory = this;

			itemSlots.Add(newItemSlot);
			itemObjects.Add(itemToAdd.itemObject);
			items.Add(itemToAdd);
		}
	}
}
