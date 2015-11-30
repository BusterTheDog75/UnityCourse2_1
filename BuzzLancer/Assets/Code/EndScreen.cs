using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class EndScreen : MonoBehaviour
	{
		private string _name = "";
		private bool _hasAddedScore;
		
		public void OnGUI()
		{
			GUILayout.BeginVertical();
			
			if(GameManagerInstance.Instance.DidWin)
			{
				GUILayout.Label ("You Won");
			}
			else
			{
				GUILayout.Label ("You Lost");
			}
			
			GUILayout.Label (string.Format("With {0} points", GameManagerInstance.Instance.Points));
			
			
			if(HighScoreManager.Instance.CanAddHighScore(GameManagerInstance.Instance.Points))
			{
				if(!_hasAddedScore)
				{
					GUILayout.Label ("You got a high score. Enter Your Name!");
					_name = GUILayout.TextField (_name);
					
					if(GUILayout.Button ("Save Score"))
					{
						HighScoreManager.Instance.AddHighScore(_name, GameManagerInstance.Instance.Points);
						_hasAddedScore = true;
					}
				}
				else
				{	
					GUILayout.Label("Score Added!");
				}
			}
			else
			{
				GUILayout.Label ("You Didn't get a high score");
			}
			
			
			if(GUILayout.Button ("Close"))
			{
				Application.LoadLevel ("StartScreen");
			}
			
			GUILayout.EndVertical();
		}
	}
}
