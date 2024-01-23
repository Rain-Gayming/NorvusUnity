using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Norvus.Inventory
{
	public class Inventory : MonoBehaviour
	{
		public List<IItem> items;
		public ItemDatabase itemDatabase;

		[BoxGroup("Debugging")]
		public TMP_InputField itemTextID;

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
	}
}
