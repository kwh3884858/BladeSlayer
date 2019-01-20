using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Skylight
{
	public class BaseScene : MonoBehaviour
	{
		// Use this for initialization
		public Dictionary<string, object> m_UserData = null;
		void Start ()
		{
		}

		public void AddGameObject<T> () where T : MonoBehaviour
		{
			GameObject go = new GameObject ();
			go.name = typeof (T).ToString ();
			go.AddComponent<T> ();
			go.transform.SetParent (transform);
		}

		public virtual void SceneInit ()
		{
			EventManager.Instance ().Notify ((int)LogicType.SceneInit);
		}
		public virtual void SceneShow ()
		{
			EventManager.Instance ().Notify ((int)LogicType.SceneOpen);

		}
		public virtual void SceneClose ()
		{
			EventManager.Instance ().Notify ((int)LogicType.SceneClose);

		}

		public virtual void SceneDestory ()
		{

		}
	}
}
