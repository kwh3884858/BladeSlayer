using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skylight
{
	abstract public class SceneEvent : EventArgs
	{

		private string m_sceneName;

		protected SceneEvent (string sceneName)
		{
			m_sceneName = sceneName;
		}

		public string GetSceneName ()
		{
			return m_sceneName;
		}
	}

	public class SceneLoadedEvent : SceneEvent
	{
		public SceneLoadedEvent (string sceneName) :
		 base (sceneName)
		{

		}
	}

	public class SceneEnterEvent : SceneEvent
	{
		public SceneEnterEvent (string sceneName) :
		 base (sceneName)
		{

		}
	}

	public class SceneLeaveEvent : SceneEvent
	{
		public SceneLeaveEvent (string sceneName) :
		 base (sceneName)
		{

		}
	}

}
