using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Code
{
	public class AsteroidManager : MonoBehaviour
	{
		private List<Asteroid> _asteroids;
		private Player _player;
		
		
		public Asteroid AsteroidPrefab;
		
		public int MaxAsteroids;
		public int MaxVisibleAsteroids;
		
		public void Awake()
		{
			_asteroids = new List<Asteroid>();
			_player = (Player)FindObjectOfType<Player>();
			
			
		}
		
		public void Start()
		{
			for(var i = 0; i < MaxAsteroids; i++)
			{
				var asteroid = (Asteroid)Instantiate(AsteroidPrefab);
				asteroid.gameObject.name = "Asteroid " + i;
				asteroid.Deactivate();
				_asteroids.Add (asteroid);
			}
		}
		
		public void LateUpdate()
		{
			var totalVisible = 0;
			
			foreach(var asteroid in _asteroids.Where(a => a.IsActive))
			{
				asteroid.UpdatePlayerPosition (_player.transform.position);
				
				if(asteroid.IsVisible)
				{
					totalVisible++;
				}
			}
			
			for(var i = 0; i < _asteroids.Count; i++)
			{
				var asteroid = _asteroids[i];
				
				if(asteroid.IsActive)
				{
					if(asteroid.IsVisible)
					{
						continue;
					}
					
					if(asteroid.DistanceSquared < (50 * 50))
					{
						continue;
					}
				}
				
				if(totalVisible < MaxVisibleAsteroids)
				{
					ActivateAsteroid(asteroid);
					totalVisible++;
				}
				else
				{
					asteroid.Deactivate();
				}
			}
		}
		
		public void ActivateAsteroid(Asteroid asteroid)
		{
			asteroid.Activate ();
			
			var rotation = new Vector3(Random.Range (0.0f, 300.0f), Random.Range (0.0f, 300.0f), Random.Range (0.0f, 300.0f));
			
			var direction = new Vector3(Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
			
			var scale = (Random.Range (0.0f, 1.0f) > 0.3f )
				? new Vector3(Random.Range(25.0f, 90.0f),Random.Range(25.0f, 90.0f), Random.Range(25.0f, 90.0f))
					: new Vector3(Random.Range (110.0f, 160.0f), Random.Range (110.0f, 160.0f), Random.Range (110.0f, 160.0f));
					
			var velocity = Random.Range (15.0f, 25.0f);
			
			var position = Camera.main.ViewportToWorldPoint (new Vector3(Random.Range (-0.5f, 1.5f), Random.Range (-0.5f, 1.5f), ((Random.Range (0.0f, 1.0f)*300.0f) + 150.0f)));
			
			asteroid.Init (position, rotation, direction, scale, velocity);
			
		}
	}
}
