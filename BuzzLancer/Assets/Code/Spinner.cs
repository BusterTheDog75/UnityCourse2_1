using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class Spinner : MonoBehaviour
	{
		public bool Direction;

		// Update is called once per frame
		void Update ()
		{
			transform.Rotate (0.0f, 0.0f, Time.deltaTime * 20.0f * (Direction ? 1.0f : -1.0f), Space.Self);
		}
	}
}
