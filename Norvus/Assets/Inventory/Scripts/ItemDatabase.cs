using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Inventory
{
	[CreateAssetMenu(menuName = "Inventory/Database")]
	public class ItemDatabase : ScriptableObject
	{
		public List<ItemObject> itemsInDatabase;

		private void OnEnable()
		{
			ClearEmpties();
        }

		public void ClearEmpties()
		{
			for (int i = 0; i < itemsInDatabase.Count; i++)
			{
				if (itemsInDatabase[i] == null)
				{
					itemsInDatabase.RemoveAt(i);
					ClearEmpties();
				}
			}
		}
	}
}