using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Inventory
{
	public enum EItemType
	{
		weapon,
		armour,
		consumable,
		readable,
		keys,
		misc
	}

	public enum EWeaponType
	{
		sword,
		axe,
		mace,
		spear,
		bow,
		crossBow,
		throwable
	}

	public enum EArmourType
	{
		clothing,
		helmet,
		hat,
		chest,
		mail,
		leg,
		legMail,
		boots,
		gloves,
		gauntlets,
	}

	public enum EConsumablesType
	{
		potion,
		poison,
		food,
		drink,
		ingredient,
	}

	public enum EReadableTypes
	{
		book,
		journel,
		note,
		scroll
	}
}