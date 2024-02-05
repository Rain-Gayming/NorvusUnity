using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Player
{
	public class PlayerCursorManager : MonoBehaviour
	{
		[BoxGroup("Cursor")]
		public bool isCursorVisible;

		public void ToggleCursor()
		{
			isCursorVisible = !isCursorVisible;

			Cursor.visible = isCursorVisible;

			if (isCursorVisible )
			{
				Cursor.lockState = CursorLockMode.None;
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
		}


		public void ToggleCursor(bool isVisible)
		{
			isCursorVisible = isVisible;

			Cursor.visible = isCursorVisible;

			if (isCursorVisible)
			{
				Cursor.lockState = CursorLockMode.None;
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
		}
	}

}