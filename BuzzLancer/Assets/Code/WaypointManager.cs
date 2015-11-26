using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class WaypointManager : MonoBehaviour
	{
		public Waypoint FirstWaypoint;
		
		private Waypoint _currentWaypoint;
		
		private Player _player;
		
		private LevelManager _levelManager;
		
		
		// Use this for initialization
		public void Start ()
		{
			_currentWaypoint = FirstWaypoint;
			
			var waypoint = _currentWaypoint.Next;
			while(waypoint != null)
			{
				waypoint.gameObject.SetActive(false);
				waypoint = waypoint.Next;
			}
			
			_player = (Player)FindObjectOfType<Player>();
			_levelManager = (LevelManager)FindObjectOfType<LevelManager>();
		}
		
		public void PlayerHitWaypoint (Waypoint waypoint)
		{
			_levelManager.WaypointHitByPlayer(waypoint);
			
			_player.MinimumVelocity = waypoint.MinimumVelocity;
			
			waypoint.Deactivate();
			
			_currentWaypoint = waypoint.Next;
			if(_currentWaypoint == null)
			{
				return;
			}
			
			_currentWaypoint.gameObject.SetActive(true);
		}
	}
}
