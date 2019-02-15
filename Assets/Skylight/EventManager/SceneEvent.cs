using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skylight
{
	public class SceneEvent : EventArgs
	{

		private readonly string m_sceneName, m_sceneParent;

		public SceneEvent (string sceneName, string sceneParent)
		{
			m_sceneName = sceneName;
			m_sceneParent = sceneParent;
		}


		public string GetSceneParent ()
		{
			return m_sceneParent;
		}

		public string GetSceneName ()
		{
			return m_sceneName;
		}
	}

}
