using UnityEngine;
using System.Collections;

namespace Assets.Code
{
	public class GameManagerInstance : MonoBehaviour
	{
		public bool IsDebug;
		public static GameManager Instance { get; private set; }
		
		public void Awake()
		{
			if(Instance == null)
			{
				var manager = new GameObject();
				Instance = manager.AddComponent<GameManager>();
				Instance.IsDebug = IsDebug;
			}
			
			Destroy (gameObject);
		}
		
		// Use this for initialization
		void Start ()
		{
		
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}
