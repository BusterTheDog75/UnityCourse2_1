using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class GameManager : MonoBehaviour
	{
		public bool IsDebug { get; set; }
		
		public int Points { get; set; }
		public bool DidWin { get; private set; }
		
		public void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}
	
		
		public void StartGame ()
		{
			Points = 0;
			DidWin = false;
		}
		
		public void EndGame(bool didWin)
		{
			if(IsDebug)
			{
				Debug.Log ("The game ended!");
				return;
			}
			
			DidWin = didWin;
			
			Application.LoadLevel ("EndScreen");
		}
	}
}
