using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class EndScreen : MonoBehaviour
	{
		public Texture WinBackground, LoseBackground;
		public GUIStyle TextStyle;
		
		private const float Width = 1920;
		private const float Height = 1080;
		
		private string _name = "";
		private bool _hasAddedScore;
		
		private GUIStyle _buttonStyle, _textFieldStyle;
		
		public void OnGUI()
		{
			if(_buttonStyle == null)
			{
				_buttonStyle = new GUIStyle(GUI.skin.button)
				{
					fontSize = 32
				};
			}
			
			if(_textFieldStyle == null)
			{
				_textFieldStyle = new GUIStyle(GUI.skin.textField)
				{
					fontSize = 32,
					margin = 
					{
						bottom = 20
					}
				};
			}
			var widthScale = Screen.width/Width;
			var heightScale = Screen.height/Height;
			
			GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(widthScale, heightScale,1.0f));
			
			if(GameManagerInstance.Instance.DidWin)
			{
				GUI.DrawTexture (new Rect(0,0,Width,Height), WinBackground);
			}
			else
			{
				GUI.DrawTexture (new Rect(0,0,Width,Height), LoseBackground);
			}
		
			GUILayout.BeginArea (new Rect(496,272,928,538));
			
			GUILayout.BeginVertical();
			
			
			GUILayout.Label (string.Format("With {0} points", GameManagerInstance.Instance.Points),  TextStyle);
			
			
			if(HighScoreManager.Instance.CanAddHighScore(GameManagerInstance.Instance.Points))
			{
				if(!_hasAddedScore)
				{
					GUILayout.Label ("You got a high score. Enter Your Name!", TextStyle);
					_name = GUILayout.TextField (_name, _textFieldStyle);
					
					if(GUILayout.Button (("Save Score"), _buttonStyle))
					{
						HighScoreManager.Instance.AddHighScore(_name, GameManagerInstance.Instance.Points);
						_hasAddedScore = true;
					}
				}
				else
				{	
					GUILayout.Label("Score Added!", TextStyle);
				}
			}
			else
			{
				GUILayout.Label ("You Didn't get a high score", TextStyle);
			}
			
			GUILayout.EndVertical();
			
			
			GUILayout.EndArea();
			
			if(GameManagerInstance.Instance.DidWin && GUI.Button (new Rect(822, 895,240,86), ""))
			{
				Application.LoadLevel ("StartScreen");
			}
			
			if(!GameManagerInstance.Instance.DidWin && GUI.Button (new Rect(843,840,240,86), ""))
			{	
				Application.LoadLevel ("StartScreen");
			}
		}
	}
}
