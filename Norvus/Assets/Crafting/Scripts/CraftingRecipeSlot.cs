using Norvus.Inventory;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEditor.Progress;

namespace Norvus.Crafting
{
	public class CraftingRecipeSlot : MonoBehaviour
	{
		[BoxGroup("References")]
		public Inventory.Inventory playerInventory;
		[BoxGroup("UI")]
		public TMP_Text itemNameText;
		[BoxGroup("UI")]
		public TMP_Text miscValueText;
		[BoxGroup("UI")]
		public TMP_Text classText;

		[BoxGroup("Recipe")]
		public CraftingRecipe recipe;

		private void Start()
		{
			if(Inventory.Inventory.playerInstance != null)
				playerInventory = Inventory.Inventory.playerInstance;
			UpdateItem();	
		}

		public void CraftItem()
		{
			bool[] hasRightItems = new bool[recipe.inputItems.Count];
            for (int i = 0; i < hasRightItems.Length; i++)
            {
				hasRightItems[i] = false;
            }

            for (int i = 0; i < recipe.inputItems.Count; i++)
            {
				if (playerInventory.itemObjects.Contains(recipe.inputItems[i].itemObject))
				{
					int itemLocation = playerInventory.itemObjects.IndexOf(recipe.inputItems[i].itemObject);

					if (playerInventory.items[itemLocation].itemAmount >= recipe.inputItems[i].itemAmount)
					{
						hasRightItems[i] = true;
					}
				}
            }

			int truers = 0;
            for (int i = 0; i < hasRightItems.Length; i++)
            {
				if (hasRightItems[i] == true)
				{
					truers++;
				}
            }

			print(truers);

			if(truers >= recipe.inputItems.Count)
			{
				for (int i = 0; i < recipe.inputItems.Count; i++)
				{
					if (playerInventory.itemObjects.Contains(recipe.inputItems[i].itemObject))
					{
						int itemLocation = playerInventory.itemObjects.IndexOf(recipe.inputItems[i].itemObject);

						if (playerInventory.items[itemLocation].itemAmount >= recipe.inputItems[i].itemAmount)
						{
							playerInventory.RemoveItem(recipe.inputItems[i]);
						}
					}
				}

				playerInventory.AddItem(recipe.outputItems);
			}
        }

		public void UpdateItem()
		{
			itemNameText.text = recipe.outputItems.itemObject.itemName;
			if (recipe.outputItems.itemAmount > 1)
			{
				itemNameText.text = itemNameText.text + " (" + recipe.outputItems.itemAmount + ")";
			}


			if (recipe.outputItems.itemObject.itemType == EItemType.weapon)
			{
				miscValueText.text = recipe.outputItems.itemObject.damageValue.ToString();
				miscValueText.gameObject.SetActive(true);
			}
			else if (recipe.outputItems.itemObject.itemType == EItemType.armour)
			{
				miscValueText.text = recipe.outputItems.itemObject.armourValue.ToString();
				miscValueText.gameObject.SetActive(true);
			}
			else
			{
				miscValueText.gameObject.SetActive(false);
			}

			switch (recipe.outputItems.itemObject.itemType)
			{
				case EItemType.weapon:
					classText.text = recipe.outputItems.itemObject.weaponType.ToString();
					break;
				case EItemType.armour:
					classText.text = recipe.outputItems.itemObject.armourType.ToString();
					break;
				case EItemType.consumable:
					classText.text = recipe.outputItems.itemObject.consumablesType.ToString();
					break;
				case EItemType.readable:
					classText.text = recipe.outputItems.itemObject.readableType.ToString();
					break;
				case EItemType.keys:
					classText.text = recipe.outputItems.itemObject.itemType.ToString();
					break;
				case EItemType.misc:
					classText.text = recipe.outputItems.itemObject.miscType.ToString();
					break;
				default:
					break;
			}
		}
	}

}