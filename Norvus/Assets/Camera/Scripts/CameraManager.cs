using Norvus.Inputs;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

namespace Norvus.Cameras
{
	public class CameraManager : MonoBehaviour
	{
		[BoxGroup("References")]
		public InputManager inputManager;
		[BoxGroup("References")]
		public Transform targetTransform;
		[BoxGroup("References")]
		public Transform cameraPivot;

		[BoxGroup("Camera Speeds")]
		public float cameraFollowSpeed = 0.2f;
		[BoxGroup("Camera Speeds")]
		public float lookSpeed;
		[BoxGroup("Camera Speeds")]
		public float pivotSpeed;


		[BoxGroup("Rotation")]
		public float lookAngle;
		[BoxGroup("Rotation")]
		public float pivotAngle;

		[BoxGroup("Camera Info")]
		public Vector3 cameraFollowVelocity;


		private void Update()
		{
			FollowTarget();
			RotateCamera();
			HandleCollisions();
		}

		public void FollowTarget()
		{
			Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);


			transform.position = targetPosition;
		}

		public void RotateCamera()
		{
			lookAngle = lookAngle + (inputManager.look.x * lookSpeed);
			pivotAngle = pivotAngle - (inputManager.look.y * pivotSpeed);

			pivotAngle = Mathf.Clamp(pivotAngle, -45, 45);

			Vector3 rot = Vector3.zero;
			rot.y = lookAngle;
			Quaternion targetRotation = Quaternion.Euler(rot);
			transform.rotation = targetRotation;

			rot = Vector3.zero;
			rot.x = pivotAngle;
			targetRotation = Quaternion.Euler(rot);
			cameraPivot.localRotation = targetRotation;
		}

		public void HandleCollisions()
		{

		}
	}
}