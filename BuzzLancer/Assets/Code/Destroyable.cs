using UnityEngine;

namespace Assets.Code
{
	public class Destroyable : MonoBehaviour
	{
		public float Health;
		public float MaxHealth;	

		public void TakeDamage(float damage, GameObject from)
		{
			Health -= damage;
			
			SendMessage ("TookDamage", from, SendMessageOptions.DontRequireReceiver);
			
			if(Health > 0.0f)
			{
				return;
			}
			SendMessage ("Destroyed", from, SendMessageOptions.DontRequireReceiver);
		}
		
	}
}

