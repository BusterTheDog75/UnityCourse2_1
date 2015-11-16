using UnityEngine;

namespace Assets.Code
{
	public class PlayerGUI
	{
		private readonly PlayerController _controller;
		private readonly Player _player;
		
		private readonly ProgressBar _velocityProgressBar;
		private readonly ProgressBar _healthProgressBar;
		
		public float CurrentCursorSize { get; private set; }
		
		public PlayerGUI(Player player, PlayerController controller)
		{
			_controller = controller;
			_player = player;
			
			_velocityProgressBar = new ProgressBar
			{
				Size = new Vector2(250.0f, 10.0f),
				Position = new Vector2(10, Screen.height - 10 - 10),
				BackgroundColor = new Color(199.0f/255.0f,231.0f/255.0f,255.0f/255.0f),
				ForegroundColor = new Color(0.0f/255.0f, 145.0f/255.0f, 255.0f/255.0f)
			};
			
			_healthProgressBar = new ProgressBar
			{
				Size = _velocityProgressBar.Size,
				Position = new Vector2(_velocityProgressBar.Position.x, _velocityProgressBar.Position.y - _velocityProgressBar.Size.y - 10.0f),
				BackgroundColor = new Color(255.0f/255.0f,199.0f/255.0f,208.0f/255.0f),
				ForegroundColor = new Color(194.0f/255.0f, 62.0f/255.0f, 62.0f/255.0f)
			};
			
			CurrentCursorSize = 20;
		}
		
		public void Update()
		{
			_velocityProgressBar.MaxValue = _controller.MaxVariableVelocity + _controller.AfterburnerModifier + _controller.MinimumVelocity;
			_velocityProgressBar.Value = _controller.CurrentVelocity;
			
			_healthProgressBar.MaxValue = _player.MaxHealth;
			_healthProgressBar.Value = _player.Health;
		}
		
		public void OnGUI()
		{
			GUI.DrawTexture (
				new Rect(
					_controller.MousePosition.x - (CurrentCursorSize / 2.0f),
					Screen.height - _controller.MousePosition.y - (CurrentCursorSize / 2.0f),
					CurrentCursorSize,
					CurrentCursorSize),
					GameResources.TargetReticule
					);
		}
	}
}
