using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class HighScoreScreen : MonoBehaviour
	{
		private const float Width = 1920;
		private const float Height = 1080;
		
		public Texture Background;
		
		public GUIStyle
			RowStyle,
			TextStyle,
			PointsStyle;
			
		public void OnGUI()
		{
			var widthScale = Screen.width/Width;
			var heightScale = Screen.height/Height;
			
			GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(widthScale, heightScale, 1.0f));
			
			GUI.DrawTexture(new Rect(0,0,Width, Height), Background);
			
			var scores = HighScoreManager.Instance.Scores;
			
			GUILayout.BeginArea (new Rect(173,186,1035,724));
			
			foreach(var score in scores)
			{
				GUILayout.BeginHorizontal(RowStyle);
				
				GUILayout.Label (score.Name, TextStyle);
				GUILayout.Label (string.Format ("{0} points", score.Points), PointsStyle);
				
				
				GUILayout.EndHorizontal();
			}
			
			GUILayout.EndArea();
			
			if(GUI.Button (new Rect(845,960,205,71), ""))
			{
				Application.LoadLevel ("StartScreen");
			}
			
		}
	}
}
