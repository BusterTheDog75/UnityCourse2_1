using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class AutoDestroyParticleSystem : MonoBehaviour
	{
		public ParticleSystem System;
		
		// Update is called once per frame
		public void Update ()
		{
			if(!System.IsAlive(true))
			{
				Destroy (gameObject);
			}
		}
	}
}
