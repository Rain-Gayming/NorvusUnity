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
		public PlayerManager playerManager;
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

		[BoxGroup("Jumping")]
		public float gravity = -9.81f;
		[BoxGroup("Jumping")]
		public float jumpHeight;
		[BoxGroup("Jumping")]
		public bool isGrounded;
		[BoxGroup("Jumping")]
		public Transform groundedCheckPoint;
		[BoxGroup("Jumping")]
		public float groundedDistance;
		[BoxGroup("Jumping")]
		public LayerMask groundMask;


		[BoxGroup("Falling")]
		public float fallLeapVelocity;
		[BoxGroup("Falling")]
		public float fallingVelocity;
		[BoxGroup("Falling")]
		public float inAirTime;

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
			isGrounded = Physics.CheckSphere(groundedCheckPoint.position, groundedDistance, groundMask);

			HandleMovement();
			HandleRotation();
			HandleFallingAndLanding();


			if (inputManager.jump && isGrounded)
			{
				HandleJump();
			}
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

		public void HandleJump()
		{
			//animationManager.animator.SetBool("isJumping", true);
			//animationManager.PlayTargetAnimation("Jump", false);

			float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
			Vector3 playerVelocity = moveDirection;
			playerVelocity.y = jumpVelocity;
			rb.velocity = playerVelocity;

			inputManager.jump = false;
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

		public void HandleFallingAndLanding()
		{
			RaycastHit hit;
			Vector3 rayCastOrigin = transform.position;

			if (!isGrounded)
			{
				if (!playerManager.isInteracting)
				{
					//play falling animation
				}

				inAirTime = inAirTime + Time.deltaTime;
				rb.AddForce(transform.forward * fallLeapVelocity);
				rb.AddForce(-Vector3.up * fallingVelocity * inAirTime);
			}else
			{
				if(inAirTime != 0)
				{
					//play landing animation
					inAirTime = 0;
				}
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

		[BoxGroup("References")]
		[Button]
		public void ResetPlayer()
		{
			transform.position = new Vector3(0, 2, 0);
		}
	}
}