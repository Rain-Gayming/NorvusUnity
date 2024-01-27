using Norvus.Equipment;
using Norvus.Inventory;
using Norvus.Inventory.Tabs;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

namespace Norvus.Crafting
{
	public class CraftingUI : MonoBehaviour
	{
		[BoxGroup("Recipes")]
		public CraftingRecipeDatabase database;

		[BoxGroup("UI")]
		public List<InventoryTab> inventoryTabs;
		[BoxGroup("UI")]
		public List<GameObject> itemSlots;

		[BoxGroup("Item Slots")]
		public GameObject basicItemSlot;

		public void Start()
		{
            for (int i = 0; i < database.recipes.Count; i++)
            {
				AddNewRecipeSlot(database.recipes[i]);
            }
        }

		public void AddNewRecipeSlot(CraftingRecipe recipe)
		{
			for (int i = 0; i < inventoryTabs.Count; i++)
			{
				if (recipe.outputItems.itemObject.itemType == inventoryTabs[i].itemType)
				{
					switch (inventoryTabs[i].itemType)
					{
						case EItemType.weapon:
							if (recipe.outputItems.itemObject.weaponType == inventoryTabs[i].weaponType)
							{
								AddNewSlotUI(inventoryTabs[i].grid.transform, recipe);
							}
							else
							{
								continue;
							}
							break;
						case EItemType.armour:
							if (recipe.outputItems.itemObject.armourType == inventoryTabs[i].armourType)
							{
								AddNewSlotUI(inventoryTabs[i].grid.transform, recipe);
							}
							else
							{
								continue;
							}
							break;
						case EItemType.consumable:
							if (recipe.outputItems.itemObject.consumablesType == inventoryTabs[i].consumablesType)
							{
								AddNewSlotUI(inventoryTabs[i].grid.transform, recipe);
							}
							else
							{
								continue;
							}
							break;
						case EItemType.readable:
							if (recipe.outputItems.itemObject.readableType == inventoryTabs[i].readableType)
							{
								AddNewSlotUI(inventoryTabs[i].grid.transform, recipe);
							}
							else
							{
								continue;
							}
							break;
						case EItemType.keys:
							AddNewSlotUI(inventoryTabs[i].grid.transform, recipe);
							break;
						case EItemType.misc:
							AddNewSlotUI(inventoryTabs[i].grid.transform, recipe);
							break;
						default:
							break;
					}
					break;
				}
			}
		}

		public void AddNewSlotUI(Transform tab, CraftingRecipe recipe)
		{
			GameObject newCraftingSlot = Instantiate(basicItemSlot);
			newCraftingSlot.transform.SetParent(tab);
			newCraftingSlot.transform.localScale = Vector3.one;
			newCraftingSlot.GetComponent<CraftingRecipeSlot>().recipe = recipe;

			itemSlots.Add(newCraftingSlot);
		}
	}
}