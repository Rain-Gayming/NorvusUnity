using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Inputs
{
	public class InputManager : MonoBehaviour
	{
		public PlayerInputs inputs;

		[BoxGroup("Movement")]
		public Vector2 movement;
		[BoxGroup("Movement")]
		public bool jump;


		[BoxGroup("Camera")]
		public Vector2 look;

		public void Awake()
		{
			inputs = new PlayerInputs();
			inputs.Enable();
		}

		public void Update()
		{
			movement = inputs.Movement.movement.ReadValue<Vector2>();
			look = inputs.Camera.Look.ReadValue<Vector2>();

			inputs.Movement.jump.performed += _ => jump = true;
			inputs.Movement.jump.canceled += _ => jump = false;
		}
	}
}
