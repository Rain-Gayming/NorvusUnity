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


		[BoxGroup("Camera")]
		public Vector2 look;

		public void Start()
		{
			inputs = new PlayerInputs();
			inputs.Enable();
		}

		public void Update()
		{
			movement = inputs.Movement.movement.ReadValue<Vector2>();
			look = inputs.Camera.Look.ReadValue<Vector2>();
		}
	}
}
