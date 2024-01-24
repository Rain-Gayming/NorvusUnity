using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Norvus.Inventory
{
	[CreateAssetMenu(menuName = "Inventory/Item")]
	public class ItemObject : ScriptableObject
	{
		public string itemName;
		public bool canStack;

		[BoxGroup("Item Type")]
		public EItemType itemType;
		[BoxGroup("Item Type")] [ShowIf("itemType", EItemType.weapon, true)]
		public EWeaponType weaponType;
		[BoxGroup("Item Type")] [ShowIf("itemType", EItemType.armour, true)]
		public EArmourType armourType;
		[BoxGroup("Item Type")]	[ShowIf("itemType", EItemType.armour, true)]
		public int armourValue;

		[BoxGroup("Item Type")] [ShowIf("itemType", EItemType.consumable, true)]
		public EConsumablesType consumablesType;
		[BoxGroup("Item Type")]	[ShowIf("itemType", EItemType.readable, true)]
		public EReadableTypes readableType;

		private void Awake()
		{
			AddToDatabase();
		}

		[Button]
		public void SetInfo()
		{
			string n = name;

			string[] nn = n.Split('_');
			
			itemName = nn[1];
		}

		public void AddToDatabase()
		{
			string path = "t:ItemDatabase";
			string[] guilds = UnityEditor.AssetDatabase.FindAssets(path);

			string dbPath = UnityEditor.AssetDatabase.GUIDToAssetPath(guilds[0]);
			ItemDatabase db = (ItemDatabase)UnityEditor.AssetDatabase.LoadAssetAtPath(dbPath, typeof(ItemDatabase));

			if (!db.itemsInDatabase.Contains(this))
			{
				db.itemsInDatabase.Add(this);
			}
		}
	}
}