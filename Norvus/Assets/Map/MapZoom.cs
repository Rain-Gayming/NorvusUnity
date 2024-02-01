using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Norvus.Map 
{
	public class MapZoom : MonoBehaviour
	{
		[BoxGroup("UI")]
		public Transform mapObject;

		[BoxGroup("Zooming")]
		public float zoomSpeed;

		public void Update()
		{
			if (Input.mouseScrollDelta.y != 0)
			{
				float newScale = mapObject.localScale.x;

				float zoomScale = Input.mouseScrollDelta.y * Time.deltaTime * zoomSpeed;
				newScale += zoomScale;

				newScale = Mathf.Clamp(newScale, 0.25f, 1.25f);

				mapObject.localScale = new Vector2(newScale, newScale);
			}
		}
	}
}
