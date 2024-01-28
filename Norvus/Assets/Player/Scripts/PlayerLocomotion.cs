using Norvus.Enums;
using Norvus.Inputs;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Player 
{
	public class PlayerLocomotion : MonoBehaviour
	{
		[BoxGroup("References")]
		public InputManager inputManager;
		[BoxGroup("References")]
		public Transform cameraObject;
		[BoxGroup("References")]
		public Rigidbody rb;

		[BoxGroup("Movement Speed")]
		public float currentMoveSpeed;
		[BoxGroup("Movement Speed")]
		public float movementPercentage = 1;
		[BoxGroup("Movement Speed")]
		public float crouchSpeed;
		[BoxGroup("Movement Speed")]
		public float walkSpeed;
		[BoxGroup("Movement Speed")]
		public float runSpeed;
		[BoxGroup("Movement Speed")]
		public float sprintSpeed;


		[BoxGroup("Rotation")]
		public float rotationSpeed;
		[BoxGroup("Rotation")]
		public Quaternion storedRotation;


		[BoxGroup("Movement Info")]
		public EMovementType currentMoveType;
		[BoxGroup("Movement Info")]
		public Vector3 moveDirection;
		[BoxGroup("Movement Info")]
		public Vector3 movementVelocity;

		public void Awake()
		{
			HandleSwitchMoveType(EMovementType.running);
		}

		private void Update()
		{
			HandleMovement();
			HandleRotation();
		}

		public void HandleMovement()
		{
			moveDirection = cameraObject.forward * inputManager.movement.y;
			moveDirection = moveDirection + cameraObject.right * inputManager.movement.x;
			moveDirection.Normalize();
			moveDirection.y = 0;

			movementVelocity = moveDirection * currentMoveSpeed * movementPercentage;
			rb.velocity = movementVelocity;
		}

		public void HandleSwitchMoveType(EMovementType movementType)
		{
			switch (movementType) 
			{
				case EMovementType.crouching:
					currentMoveSpeed = crouchSpeed;
					break;
				case EMovementType.walking:
					currentMoveSpeed = walkSpeed;
					break;
				case EMovementType.running:
					currentMoveSpeed = runSpeed;
					break;
				case EMovementType.sprinting:
					currentMoveSpeed = sprintSpeed;
					break;
			}
		}

		public void HandleRotation()
		{
			Vector3 targetDirection = Vector3.zero;

			targetDirection = cameraObject.forward * inputManager.movement.y;
			targetDirection = targetDirection + cameraObject.right * inputManager.movement.x;
			targetDirection.Normalize();
			targetDirection.y = 0;

			if(targetDirection != Vector3.zero)
			{
				Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
				Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
				transform.rotation = playerRotation;
				storedRotation = playerRotation;
			}
			else
			{
				transform.rotation = storedRotation;
			}

		}
	}
}