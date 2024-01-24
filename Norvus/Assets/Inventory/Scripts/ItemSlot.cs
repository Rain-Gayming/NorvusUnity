using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Norvus.Inventory
{
	public class ItemSlot : MonoBehaviour
	{
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
	}
}