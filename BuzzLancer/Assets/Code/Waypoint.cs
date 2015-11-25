using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Code
{
	public class Waypoint : MonoBehaviour
	{
		public Waypoint Next;
		
		public float TimeModifier, MinimumVelocity;
		
		public Shader AlphaShader;
		
		private WaypointManager _manager;
		private IEnumerable<Renderer> _renderers;
		
		
		private float _alpha;
		private bool _deactivating;
		
		public void Start()
		{
			_manager = (WaypointManager)FindObjectOfType<WaypointManager>();
			_renderers = GetComponentsInChildren<Renderer>();
			
			_alpha = 1.0f;
			_deactivating = false;
		}
		
		public void Deactivate()
		{
			_deactivating = true;
			
			foreach(var render in _renderers)
			{
				render.material.shader = AlphaShader;
			}
		}
		
		public void OnTriggerEnter(Collider collision)
		{
			if(collision.gameObject.FindComponent<Player>() == null)
			{
				return;
			}
			
			_manager.PlayerHitWaypoint(this);
		}
		
		public void Update()
		{
			if(!_deactivating)
			{
				return;
			}
			
			_alpha = Mathf.Lerp (_alpha, 0.0f, Time.deltaTime * 5.0f);
			foreach(var render in _renderers)
			{
				render.material.color = new Color (1,1,1, _alpha);
			}
			
			if(_alpha < 0.01f)
			{
				gameObject.SetActive(false);
			}
		}		
	}
}
