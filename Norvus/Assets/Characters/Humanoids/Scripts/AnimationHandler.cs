using Norvus.Player;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Characters
{
	public class AnimationHandler : MonoBehaviour
	{
		[BoxGroup("References")]
		public PlayerManager playerManager;
		[BoxGroup("References")]
		public Animator anim;
		[BoxGroup("Values")]
		public bool canRotate;

		public void UpdateAnimatorValues(float vert, float hor, bool isSprinting)
		{
			anim.SetFloat("x", hor, 0.1f, Time.deltaTime);
			anim.SetFloat("y", vert, 0.1f, Time.deltaTime);
		}

		public void PlayTargetAnimation(string targetName, bool isInteracting)
		{
			//anim.applyRootMotion = isInteracting;
			anim.SetBool("isInteracting", isInteracting);
			anim.CrossFade(targetName, 0.2f);
		}
		public void SetRotate(bool value)
		{
			canRotate = value;
		}

		public void OnAnimatorMove()
		{
			if (!playerManager.isInteracting)
			{
				return;
			}
		}
	}
}