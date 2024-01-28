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

		public void Start()
		{
			inputs = new PlayerInputs();
			inputs.Enable();
		}

		public void Update()
		{
			movement = inputs.Movement.movement.ReadValue<Vector2>();
		}
	}
}
