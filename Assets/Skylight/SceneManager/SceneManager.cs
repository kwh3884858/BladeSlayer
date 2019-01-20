using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

namespace Skylight
{
	public class SceneManager : GameModule<SceneManager>
	{

		Dictionary<string, GameObject> mAllScenes = new Dictionary<string, GameObject> ();
		private BaseScene mCurrentScene = null;

		public BaseScene m_currentScene {
			get {
				return mCurrentScene;
			}
		}

		public void ShowScene<T> (Dictionary<string, object> varList = null) where T : BaseScene
		{
			if (mCurrentScene != null) {

				mCurrentScene.gameObject.SetActive (false);
				mCurrentScene.GetComponent<BaseScene> ().SceneClose ();
				Debug.Log ("destroy");
				mCurrentScene = null;
			}
			//todo:enhancement: refactor scenemanager
			string name = typeof (T).ToString ();
			GameObject uiObject;
			if (!mAllScenes.TryGetValue (name, out uiObject)) {
				//Debug.Log ("Poruduce new scene");
				string perfbName = "Scenes/" + typeof (T).ToString ();
				//Debug.Log ("Loaded Perfab : " + perfbName);
				GameObject perfb = AssetsManager.LoadScene<GameObject> (perfbName);
				uiObject = GameObject.Instantiate (perfb);
				uiObject.name = name;

				T t = uiObject.AddComponent<T> ();
				uiObject.transform.SetParent (transform);
				t.SceneInit ();

				mAllScenes.Add (name, uiObject);
			} else {

				uiObject.SetActive (true);

			}

			if (uiObject) {
				T scene = uiObject.GetComponent<T> ();
				scene.SceneShow ();
				if (varList != null)
					scene.m_UserData = varList;

				mCurrentScene = scene;

				uiObject.SetActive (true);
			}
		}
		public void ReloadScene<T> () where T : BaseScene
		{
			if (!mCurrentScene) {
				Debug.Log ("Dont have current scene!");
				return;
			}

			string sceneName = typeof (T).ToString ();

			if (sceneName == mCurrentScene.name) {
				Debug.Log ("Current scene is ready reload");
				mCurrentScene = null;

			}
			BaseScene destoryedScene = mAllScenes [sceneName].GetComponent<BaseScene> ();
			destoryedScene.SceneDestory ();
			if (!mAllScenes.Remove (sceneName)) {
				Debug.Log ("Current scene doesn`t exist in all scenes cache !");
			}

			Destroy (destoryedScene.gameObject);

			ShowScene<T> ();

			//ShowScene<>
		}


		public void CloseScene ()
		{
			if (mCurrentScene) {
				mCurrentScene.GetComponent<BaseScene> ().SceneClose ();
				mCurrentScene.gameObject.SetActive (false);
				mCurrentScene = null;
			}
		}

		public void UnloadAllScene ()
		{

			Dictionary<string, GameObject>.Enumerator etor = mAllScenes.GetEnumerator ();
			while (etor.MoveNext ()) {
				Destroy (etor.Current.Value);
			}
			mAllScenes.Clear ();

		}
	}
}