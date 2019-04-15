using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skylight
{
	public class GameRoot : MonoSingleton<GameRoot>
	{
		VirtualMachineInterface virtualMachineInterface;

		// Use this for initialization
		void Start ()
		{
			//AddGameObject<NetService>();
			//DONT CHANGE ORDER
			//不要修改顺序，有相互依赖关系
			AddGameObject<EventManager> ();


			AddGameObject<PollerService> ();

			//依赖Poller
			//AddGameObject<Localization> ();
			//Initialize asset bundle loader and assetmanager
			AddGameObject<AssetsManager> ();
			AddGameObject<SceneManager> ();
			AddGameObject<SoundService> ();

			AddGameObject<UIManager> ();

			AddGameObject<PrefabManager> ();
			EventManager.Instance ().LogicStart ();
			//   AddGameObject<CameraService>();
			AddGameObject<InputService> ();
			AddGameObject<TimerService> ();
			AddGameObject<Console> ();
			AddGameObject<Localization> ();
			//UIManager.Instance().ShowPanel<UIButtonPanel>();
			//SceneManager.Instance().LoadScene()
			// UIManager.Instance().ShowPanel<UIButtonPanel>();
			//SceneManager.Instance ().ShowScene<SceneCave> ();
			//UIManager.Instance ().ShowPanel<UIMainMenu> ();
			//UIManager.Instance().ShowPanel<UIMainMenuPanel>();

			AddEntitas ();

			SceneManager.Instance ().AddSceneLoadedEvent (Handlecallback);


			StartCoroutine (AfterInitialize ());
		}
		IEnumerator AfterInitialize ()
		{
			yield return null;
			SceneManager.Instance ().LoadScene ("Scene1", SceneLoadMode.Additive);
			SceneManager.Instance ().LoadScene ("scene2", SceneLoadMode.Additive);



		}
		// Update is called once per frame
		void Update ()
		{
			if (virtualMachineInterface != null) {
				virtualMachineInterface.Update ();

			}
		}

		void Handlecallback ()
		{
			virtualMachineInterface = new VirtualMachineInterface ();
			virtualMachineInterface.Start ();
			//SceneManager.Instance ().RemoveSceneLoadedEvent (Handlecallback);
		}


		public void AddSystemManger ()
		{


		}
		private void AddEntitas ()
		{
			GameObject entitas = new GameObject ("Entitas.GameControllerBehaviour");
			entitas.transform.parent = transform;

			entitas.AddComponent<GameControllerBehaviour> ();

		}


	}
}
