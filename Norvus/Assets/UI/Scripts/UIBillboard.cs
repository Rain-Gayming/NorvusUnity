using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Norvus.UI
{
	public class UIBillboard : MonoBehaviour
	{
		public Transform camTransform;

		public void Start()
		{
			camTransform = Camera.main.transform;
		}

		public void Update()
		{
			transform.LookAt(camTransform.position);
		}
	}

}