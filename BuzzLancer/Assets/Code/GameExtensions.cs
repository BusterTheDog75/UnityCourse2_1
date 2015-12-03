using UnityEngine;

namespace Assets.Code
{
	public static class GameExtensions
	{
		public static AudioSource PlayClipAtPoint(Vector3 position, AudioClip clip)
		{	
			var gameObject = new GameObject("One Shot Audio");
			var source = gameObject.AddComponent<AudioSource>();
			source.clip = clip;
			gameObject.transform.position = position;
			
			Object.Destroy(gameObject, source.clip.length);
			source.Play();
			
			return source;
		}
	
		public static T FindComponent<T>(this GameObject that) where T : Component
		{
			var component = that.GetComponent<T>();
			if(component != null)
			{
				return component;
			}
			
			var proxy = that.GetComponent<ColliderProxy>();
			if(proxy == null)
			{
				return null;
			}
			
			if(proxy.ProxyFor == null)
			{
				Debug.LogWarning ("ColliderProxy didn't specify what it was a proxy for!", that);
				return null;
			}
			
			return proxy.ProxyFor.GetComponent<T>();
		}
	}
		
}
