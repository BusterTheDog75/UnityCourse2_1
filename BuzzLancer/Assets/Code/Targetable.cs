using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class Targetable : MonoBehaviour
	{
		private const float BaseOffscreenSize = 16;
		private const float BaseMaxSize = 128;
		private const float BaseMinSize = 100.0f;
		
		private const float SmoothMovement = 25.0f;
		
		private Vector3 _screenPosition, _currentPosition, _offscreenPosition, _targetPosition;
		private float _currentSize, _targetSize;
		private bool _isOffscreen;
		
		public void Update()
		{
			_isOffscreen = false;
			
			_offscreenPosition = _screenPosition = Camera.main.WorldToScreenPoint(transform.position);
			var distance = Vector3.Distance(Camera.main.transform.position, transform.position);
			
			_targetSize = Mathf.Clamp (BaseMaxSize/distance, BaseMinSize, BaseMaxSize);
			
			_targetPosition.x = _screenPosition.x - _currentSize/2.0f;
			_targetPosition.y = Screen.height - _screenPosition.y - _currentSize/2.0f;
			
			_offscreenPosition.x = _screenPosition.x - BaseOffscreenSize /2.0f;
			_offscreenPosition.y = Screen.height - _screenPosition.y - BaseOffscreenSize/2.0f;
			
			if(_screenPosition.z < 0.0f)
			{
				_isOffscreen = true;
				_offscreenPosition.x = (_screenPosition.x < Screen.width/2.0f) ? (BaseOffscreenSize/2.0f): (Screen.width - BaseOffscreenSize*2.0f);
				_offscreenPosition.y = (_screenPosition.y < Screen.height/2.0f) ? (BaseOffscreenSize/2.0f): (Screen.height - BaseOffscreenSize*2.0f);
			}
			
			if(_offscreenPosition.x < 0.0f)
			{
				_isOffscreen = true;
				_offscreenPosition.x = BaseOffscreenSize/2.0f;
			}
			else if(_currentPosition.x > Screen.width - BaseOffscreenSize)
			{
				_isOffscreen = true;
				_offscreenPosition.x = Screen.width - BaseOffscreenSize*2.0f;
			}
			
			if(_offscreenPosition.y < 0.0f)
			{
				_isOffscreen = true;
				_offscreenPosition.y = BaseOffscreenSize/2.0f;
			}
			else if(_currentPosition.y > Screen.height - BaseOffscreenSize)
			{
				_isOffscreen = true;
				_offscreenPosition.y = Screen.height - BaseOffscreenSize*2.0f;
			}
			
			_currentSize = Mathf.Lerp (_currentSize, _targetSize, Time.deltaTime * 4.0f);
			_currentPosition.x = Mathf.Lerp (_currentPosition.x, _targetPosition.x, SmoothMovement * Time.deltaTime);			
			_currentPosition.y = Mathf.Lerp (_currentPosition.y, _targetPosition.y, SmoothMovement * Time.deltaTime);			
		}
		
		public void OnGUI()
		{
			var oldColor = GUI.color;
			GUI.color = Color.yellow;
			
			if(_isOffscreen)
			{
				GUI.DrawTexture (new Rect(_offscreenPosition.x, _offscreenPosition.y, BaseOffscreenSize, BaseOffscreenSize), GameResources.OffscreenIndicator);
			}
			else
			{
				GUI.DrawTexture (new Rect(_currentPosition.x, _currentPosition.y, _currentSize, _currentSize), GameResources.TargetSquare);
			}
			GUI.color = oldColor;
		}
	}
}
