using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Player
{
	public class PlayerVaultCheck : MonoBehaviour
	{
		[BoxGroup("Check")]
		public bool objectInWay;

		private void OnTriggerEnter(Collider other)
		{
			objectInWay = true;
		}

		public void OnTriggerExit(Collider other)
		{
			objectInWay = false;
		}
	}
}
