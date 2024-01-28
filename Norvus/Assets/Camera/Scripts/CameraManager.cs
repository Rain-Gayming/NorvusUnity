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
		public Transform cameraTransform;
		[BoxGroup("References")]
		public Transform cameraPivot;

		[BoxGroup("Camera Speeds")]
		public float cameraFollowSpeed = 0.2f;
		[BoxGroup("Camera Speeds")]
		public float lookSpeed;
		[BoxGroup("Camera Speeds")]
		public float pivotSpeed;

		[BoxGroup("Collision")]
		public float cameraCollisionRadius = 0.2f;
		[BoxGroup("Collision")]
		public float cameraCollisionOffset = 0.2f;
		[BoxGroup("Collision")]
		public float minimumCollisionOffset = 0.2f;
		[BoxGroup("Collision")]
		public LayerMask cameraCollisonLayers;

		[BoxGroup("Rotation")]
		public float lookAngle;
		[BoxGroup("Rotation")]
		public float pivotAngle;

		[BoxGroup("Camera Info")]
		public float defaultPosition;
		[BoxGroup("Camera Info")]
		public Vector3 cameraVectorPosition;
		[BoxGroup("Camera Info")]
		public Vector3 cameraFollowVelocity;


		private void Start()
		{
			defaultPosition = cameraTransform.localPosition.z;
		}

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
			float targetPosition = defaultPosition;
			RaycastHit hit;
			Vector3 direction = cameraTransform.position - cameraPivot.position;
			direction.Normalize(); 

			if(Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), cameraCollisonLayers))
			{
				float distance = Vector3.Distance(cameraPivot.position, hit.point);
				targetPosition = targetPosition - (distance - cameraCollisionOffset);
			}

			if(Mathf.Abs(targetPosition) < minimumCollisionOffset)
			{
				targetPosition = targetPosition - minimumCollisionOffset;
			}

			cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
			cameraTransform.localPosition = cameraVectorPosition;
		}
	}
}