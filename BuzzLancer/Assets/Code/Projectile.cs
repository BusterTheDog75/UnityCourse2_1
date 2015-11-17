using UnityEngine;

namespace Assets.Code
{
	public class Projectile : MonoBehaviour
	{
		private float _timeToLive;
		private Vector3 _direction;
		private ProjectileWeapon _weapon;
		
		public void Init(ProjectileWeapon weapon, Vector3 direction)
		{
			_weapon = weapon;
			_timeToLive = _weapon.TimeToLive;
			_direction = direction;
			
			transform.LookAt(_direction + transform.position);
		}
		
		public void Update()
		{
			if((_timeToLive - Time.deltaTime) < 0.0f)
			{
				Destroy (gameObject);
				return;
			}
			
			transform.Translate (_direction * _weapon.Speed * Time.deltaTime, Space.World);	
		}
	}
}
