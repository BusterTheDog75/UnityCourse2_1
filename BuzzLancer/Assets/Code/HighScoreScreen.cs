using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class HighScoreScreen : MonoBehaviour
	{
		public void OnGUI()
		{
			var scores = HighScoreManager.Instance.Scores;
			
			GUILayout.BeginVertical();
			
			foreach(var score in scores)
			{
				GUILayout.BeginHorizontal();
				
				GUILayout.Label (string.Format("{0}", score.Name));
				GUILayout.Label (string.Format("With {0} points", score.Points));
				
				GUILayout.EndHorizontal();
			}
			
			if(GUILayout.Button("Back"))
			{
				Application.LoadLevel("StartScreen");
			}
			
			GUILayout.EndVertical();
		}
	}
}
