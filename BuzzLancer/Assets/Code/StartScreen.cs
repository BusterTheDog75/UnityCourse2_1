using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class StartScreen : MonoBehaviour
	{
		private const float Width = 1920;
		private const float Height = 1080;
		
		public string FirstLevel;
		public Texture Background;
		
		public void OnGUI()
		{
			var widthScale = Screen.width/Width;
			var heightScale = Screen.height/Height;
			
			GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(widthScale, heightScale, 1.0f));
			
			
			GUI.DrawTexture(new Rect(0,0,Width,Height),Background);
		
			if(GUI.Button (new Rect(850,315,279,100), ""))
			{
				GameManagerInstance.Instance.StartGame();
				
				Application.LoadLevel(FirstLevel);
			}
		
			if(GUI.Button (new Rect(850,500,279,108), ""))
			{
				Application.LoadLevel("HighScoreScreen");
			}
			
			if(GUI.Button (new Rect(850, 700, 279,100), ""))
			{
				Application.Quit();
			}
		}
	}
}
