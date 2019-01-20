using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skylight
{
	public class GameRoot : MonoSingleton<GameRoot>
	{
		// Use this for initialization
		void Start ()
		{
			//AddGameObject<NetService>();
			//DONT CHANGE ORDER
			//不要修改顺序，有相互依赖关系
			AddGameObject<LogicManager> ();


			AddGameObject<PollerService> ();

			//依赖Poller
			//AddGameObject<Localization> ();

			AddGameObject<SceneManager> ();
			AddGameObject<SoundService> ();

			AddGameObject<UIManager> ();

			AddGameObject<PrefabManager> ();
			LogicManager.Instance ().LogicStart ();
			//   AddGameObject<CameraService>();
			AddGameObject<InputService> ();
			AddGameObject<TimerService> ();
			AddGameObject<Console> ();
			AddGameObject<Localization> ();
			//UIManager.Instance().ShowPanel<UIButtonPanel>();

			// UIManager.Instance().ShowPanel<UIButtonPanel>();
			//SceneManager.Instance ().ShowScene<SceneCave> ();
			//UIManager.Instance ().ShowPanel<UIMainMenu> ();
			//UIManager.Instance().ShowPanel<UIMainMenuPanel>();
		}

		// Update is called once per frame
		void Update ()
		{

		}


		public void AddSystemManger ()
		{


		}


	}
}
