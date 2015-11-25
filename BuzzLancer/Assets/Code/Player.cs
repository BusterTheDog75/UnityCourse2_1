using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Code
{
	public class Player : MonoBehaviour 
	{
		public Camera Camera;
		public Destroyable Destroyable;
		public BasicWeapon BasicWeapon;
	
		private PlayerCamera _camera;
		private PlayerController _controller;
		private PlayerGUI _playerGUI;
		private PlayerWeapons _weapons;
		
		private IEnumerable<BasicWeaponMount> _mounts;
		
		public float Health { get { return Destroyable.Health; } }
		
		public float MaxHealth { get { return Destroyable.MaxHealth; } }
		
		public float MinimumVelocity
		{ 
						get { return _controller.MinimumVelocity; }
						set { _controller.MinimumVelocity = value; } 
		}
		
		public void Awake()
		{
			_camera = new PlayerCamera(this, Camera);
			_controller = new PlayerController(this);
			_playerGUI = new PlayerGUI(this, _controller);
			
			_mounts = GetComponentsInChildren<BasicWeaponMount>();
			_weapons = new PlayerWeapons(this, Camera, _controller, _mounts);
			
			// Equip default weapon to all mounts
			Equip (BasicWeapon);
		}
		
		public void Equip(BasicWeapon weapon)
		{
			foreach(var mount in _mounts)
			{
				mount.Equip(weapon);
			}
		}
		
		public void Update()
		{
			_controller.Update();
			_playerGUI.Update();
			_camera.Update();
			_weapons.Update();
		}
		
		public void OnGUI()
		{
			_playerGUI.OnGUI ();
		}
	}
}