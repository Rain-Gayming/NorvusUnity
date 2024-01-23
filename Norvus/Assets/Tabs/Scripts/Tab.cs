using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.UI.Tabs
{
	public class Tab : MonoBehaviour
	{
		public bool isOn;
		public GameObject tabObject;
		
		public void SetVisible(bool isVisible)
		{
			isOn = isVisible;
			tabObject.SetActive(isOn);
		}
	}
}
