using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Player
{
	public class PlayerVaulting : MonoBehaviour
	{
		[BoxGroup("References")]
		public PlayerManager playerManager;
		[BoxGroup("References")]
		public PlayerVaultCheck vaultingCheck;

		[BoxGroup("Vaulting")]
		public bool canVault;

		private void OnTriggerStay(Collider other)
		{
			print(other);
			canVault = !vaultingCheck.objectInWay;
		}

		private void OnTriggerExit(Collider other)
		{

			if (other.gameObject.layer == playerManager.playerLocomotion.groundMask)
			{
				canVault = false;
			}
		}
	}
}
