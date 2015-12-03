using UnityEngine;

namespace Assets.Code
{
	public class ProjectileWeapon : BasicWeapon
	{
		public Projectile Prefab;
		
		public AudioClip Sound;
		
		public float 
				Speed,
				Damage,
				FireRate,
				TimeToLive;
		
		private float _cooldown;
		
		public override void Fire(Vector3 position, Vector3 direction)
		{
			if((_cooldown -= Time.deltaTime) > 0.0f)
			{
				return;
			}
			
			AudioSource.PlayClipAtPoint(Sound, position, 0.4f);
			
			var projectile = (Projectile)Instantiate (Prefab, position, Quaternion.identity);
			projectile.Init (this, direction);
			
			_cooldown = FireRate;
		}
	}
}

