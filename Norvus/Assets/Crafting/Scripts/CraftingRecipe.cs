using Norvus.Inventory;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Norvus.Crafting
{
	[CreateAssetMenu(menuName = "Crafting/Crafting Recipe")]
	public class CraftingRecipe : ScriptableObject
	{
		public List<IItem> inputItems;
		public IItem outputItems;

		private void Awake()
		{
			AddToDatabase();
		}

		public void AddToDatabase()
		{
			string path = "t:CraftingRecipeDatabase";
			string[] guilds = UnityEditor.AssetDatabase.FindAssets(path);

			string dbPath = UnityEditor.AssetDatabase.GUIDToAssetPath(guilds[0]);
			CraftingRecipeDatabase db = (CraftingRecipeDatabase)UnityEditor.AssetDatabase.LoadAssetAtPath(dbPath, typeof(CraftingRecipeDatabase));

			if (!db.recipes.Contains(this))
			{
				db.recipes.Add(this);
			}
		}
	}
}
