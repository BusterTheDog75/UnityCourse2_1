using UnityEngine;

namespace Assets.Code
{
	public class PlayerCamera
	{
		private readonly Player _player;
		private readonly Camera _camera;
		
		public float MovementDamp {	get; set; }
		
		public PlayerCamera (Player player, Camera camera)
		{
			MovementDamp = 8.0f;
			
			_player = player;
			_camera = camera;
		}
		
		public void Update()
		{
			var position = _player.transform.TransformPoint(0.0f, 0.5f, -5f);
			_camera.transform.position = Vector3.Lerp (_camera.transform.position, position, Time.deltaTime * MovementDamp);
			
			_camera.transform.LookAt(_player.transform.TransformPoint (0.0f, 0.0f, 50.0f), _player.transform.up);
		}
	}
}

