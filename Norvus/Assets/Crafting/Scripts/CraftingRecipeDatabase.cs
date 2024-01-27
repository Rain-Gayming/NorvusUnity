using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Crafting
{
	[CreateAssetMenu(menuName = "Crafting/Crafting Database")]
	public class CraftingRecipeDatabase : ScriptableObject
	{
		public List<CraftingRecipe> recipes;
	}
}
