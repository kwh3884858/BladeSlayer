using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Skylight
{
	/// <summary>
	/// 逻辑类型，用于EventManager
	/// </summary>
	public enum LogicType
	{
		SceneInit,
		SceneOpen,
		SceneClose,
		SceneStart,

		PanelInit,
		PanelOpen,
		PanelClose,
		PanelStart,

		MainMenuInit,
		MainMenuOpen,
		MainMenuClose,
		MainMenuStart,

		DialogPlayerStart,
		DialogPlayerCallback,

		//切换语言的时候触发
		Changelanguage,

	}

	public class EventManager : GameModule<EventManager>
	{
		LogicBase m_currentLogic;

		public override void SingletonInit ()
		{
			base.SingletonInit ();

		}

		public void LogicStart ()
		{
			Instance ().OpenLogic<MainMenuLogic> ();
		}

		public T AddLogic<T> () where T : LogicBase
		{
			var go = new GameObject ();
			go.name = typeof (T).ToString ();
			T t = go.AddComponent<T> ();
			m_currentLogic = t;
			go.transform.SetParent (transform);

			t.LogicInit ();
			t.LogicShow ();
			return t;
		}

		public T GetLogic<T> () where T : LogicBase
		{
			Transform logicTran = transform.Find (typeof (T).ToString ());
			if (logicTran != null) {
				T t = logicTran.GetComponent<T> ();
				m_currentLogic = t;
				t.LogicShow ();
				return t;
			} else {
				return null;
			}
		}

		public T OpenLogic<T> () where T : LogicBase
		{
			if (m_currentLogic != null) {
				m_currentLogic.LogicClose ();
				m_currentLogic = null;
			}

			T t = null;
			t = GetLogic<T> ();
			if (t == null) {
				t = AddLogic<T> ();
			}

			return t;
		}

		public void Notify (int eventId, System.Object vars = null)
		{
			//Debug.Log ((SkylightStaticData.LogicType)eventId);
			m_currentLogic.Notify (eventId, vars);
			m_currentLogic.DoEvent (eventId, vars);
		}

		public void RegisterCallback (int nEventID, LogicBase.LogicEventHandler handler)
		{
			m_currentLogic.RegisterCallback (nEventID, handler);
		}

		//new one
		public Dictionary<string, EventHandler<EventArgs>> m_allEvent =
		new Dictionary<string, EventHandler<EventArgs>> ();

		public void AddEventListener<T> (EventHandler<T> handler) where T : EventArgs
		{
			m_allEvent.Add (typeof (T).ToString (), handler as EventHandler<EventArgs>);
		}
		public void RemoveEventListener () { }
		public void SendEvent<T> (T message) where T : EventArgs
		{
			string eventName = typeof (T).ToString ();
			if (!m_allEvent.ContainsKey (eventName)) { return; };
			EventHandler<T> temp = m_allEvent [eventName] as EventHandler<T>;
			if (temp != null) temp (this, message);
		}
	}

}