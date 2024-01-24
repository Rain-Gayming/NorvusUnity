using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Norvus.UI.Tabs
{
	public class TabManager : MonoBehaviour
	{
		public List<Tab> tabs;

		private void Start()
		{
			OpenAllTabs();
			OpenTab(tabs[0]);
		}

		public void CloseAllTabs()
		{
			for (int i = 0; i < tabs.Count; i++)
			{
				tabs[i].gameObject.SetActive(false);
			}
		}
		public void OpenAllTabs()
		{
			for (int i = 0; i < tabs.Count; i++)
			{
				tabs[i].gameObject.SetActive(true);
			}
		}

		public void OpenTab(Tab tab)
		{
			CloseAllTabs();

			tab.gameObject.SetActive(true);
		}
	}
}