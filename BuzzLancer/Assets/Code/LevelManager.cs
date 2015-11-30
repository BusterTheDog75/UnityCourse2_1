using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class LevelManager : MonoBehaviour
	{
	
		public float TimeLeft;
		public string NextLevel;
		
		// Update is called once per frame
		void Update ()
		{
			TimeLeft -= Time.deltaTime;
			
			if(TimeLeft < 0.0f)
			{
				GameManagerInstance.Instance.EndGame(false);
			}
		}
		
		public void AsteroidDestroyedByPlayer(Asteroid asteroid)
		{
			GameManagerInstance.Instance.Points += asteroid.Level * 50;
			
		}
		
		public void WaypointHitByPlayer(Waypoint waypoint)
		{
			if(waypoint.Next == null)
			{
				GameManagerInstance.Instance.Points += (int)Mathf.Ceil(TimeLeft) * 10;
				
				if(!string.IsNullOrEmpty(NextLevel))
				{
					if(GameManagerInstance.Instance.IsDebug)
					{
						Debug.Log ("You are moving onto the next level");
					}
					else
					{
						Application.LoadLevel (NextLevel);
					}
				}
				else
				{
					GameManagerInstance.Instance.EndGame (true);
				}
			}
			
			TimeLeft += waypoint.TimeModifier;
		}
	}
}
