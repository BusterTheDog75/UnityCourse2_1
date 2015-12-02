using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class Asteroid : MonoBehaviour
	{
		private const int MaxLevel = 6;
		
		private float _alpha;
		private float _velocity;
		
		private Vector3 _direction;
		
		private AsteroidManager _asteroidManager;
		private Destroyable _destroyable;
		
		public GameObject Effect;
		
		public int Level { get; private set; }
		
		public float DistanceSquared { get; private set; }
		
		public bool IsVisible { get; private set; }
		
		public bool IsActive { get; private set; }
		
		public void Awake()
		{
			_asteroidManager = (AsteroidManager)FindObjectOfType<AsteroidManager>();
			_destroyable = GetComponent<Destroyable>();
		}
		
		public void UpdatePlayerPosition(Vector3 playerPosition)
		{
			var point = Camera.main.WorldToViewportPoint (transform.position);
			IsVisible = (point.x > -0.5f) && (point.x < 1.5f) && (point.y > -0.5f) && (point.y < 1.5f) && point.z > 0.0f;
			
			DistanceSquared = (transform.position - playerPosition).sqrMagnitude;
		}
		
		public void Update()
		{
			if(_alpha < 1.0f)
			{
				_alpha = Mathf.Lerp (_alpha, 1.0f, Time.deltaTime * 10.0f);
				
				if(_alpha > 0.9f)
				{
					_alpha = 1.0f;
				}
				
				renderer.material.color = new Color(1.0f,1.0f,1.0f, _alpha);
			}
			
			transform.Translate(_direction * _velocity * Time.deltaTime);
		}
		
		public void Init(Vector3 position, Vector3 rotation, Vector3 direction, Vector3 scale, float velocity)
		{
			transform.position = position;
			transform.localEulerAngles = rotation;
			transform.localScale = scale;
			
			Level = (int)Mathf.Ceil((scale.magnitude - 25.0f) / 255.0f * (MaxLevel - 1)) + 1;
			_destroyable.MaxHealth = _destroyable.Health = (Level * 100);
			
			_direction = direction;
			_velocity = velocity;
			
			IsVisible = false;
		}
		
		public void OnGUI()
		{
			var position = Camera.main.WorldToScreenPoint(transform.position);
			
			GUI.Label(new Rect(position.x, Screen.height - position.y, 200, 50), Level.ToString());
		}
		public void Activate()
		{
			IsActive = true;
			gameObject.SetActive(true);
			_alpha = 0.0f;
			renderer.material.color = new Color(1.0f,1.0f,1.0f,0.0f);
		}
		
		public void Deactivate()
		{
			IsActive = false;
			gameObject.SetActive(false);
		}
		
		public void Destroyed(GameObject from)
		{
			Instantiate (Effect, transform.position, transform.rotation);
			
			_asteroidManager.AsteroidDestroyed(this);
		}
		
		public void OnTriggerEnter(Collider collision)
		{
			var destroyable = collision.gameObject.FindComponent<Destroyable>();
			if(destroyable == null)
			{
				return;
			}
			
			destroyable.TakeDamage (Level * 50, gameObject);
			
			_destroyable.TakeDamage(_destroyable.Health, collider.gameObject);
		}
	}
}
