using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class EndScreen : MonoBehaviour
	{
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
			
			if(GUILayout.Button ("Close"))
			{
				Application.LoadLevel ("StartScreen");
			}
			
			GUILayout.EndVertical();
		}
	}
}
