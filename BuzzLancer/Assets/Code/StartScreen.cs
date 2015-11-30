using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class StartScreen : MonoBehaviour
	{
	
		public string FirstLevel;
		
		public void OnGUI()
		{
			GUILayout.BeginVertical ();
			
			if(GUILayout.Button ("Start Game"))
			{
				GameManagerInstance.Instance.StartGame();
				
				Application.LoadLevel(FirstLevel);
			}
			
			if(GUILayout.Button ("High Scores"))
			{
				Application.LoadLevel("HighScoreScreen");
			}
			
			GUILayout.EndVertical();
		}
	}
}
