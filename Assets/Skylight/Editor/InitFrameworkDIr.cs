using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

namespace Skylight
{
	public class InitFrameworkDir : Editor
	{

		/// <summary>
		/// 初始化框架文件夹
		/// </summary>
		[MenuItem ("Assets/Framework/InitFrameworkDirectory")]
		static void InitFrameworkDirectory ()
		{

			string [] frameworkDir = {
				"UI/Panel",             //存放UI的预设体
				"UI/Dialog",
				"UI/Overlay",
				"UI/Box",
				"Skylight/UI/Panel",	//框架中的UI预设体
				"Skylight/UI/Dialog",
				"Skylight/UI/Overlay",
				"Skylight/UI/Box",
				"Effects",              //视觉效果
				"Prefabs",              //存放预设
				"Plugins",				//插件
				"Scenes",               //存放场景和场景预设
				"Models",               //存放模型
                "Materials",            //材质文件
                "Shaders",              //shder文件
				"Images",               //存放图片
                "Images/Character",
				"Images/Item",
				"Images/Map",
				"Images/Weapon",
				"Animations",
				"Animations/Character",
				"Librarys",				//所依赖的库，例如本地数据库
				"Resources/Sound/Music",
				"Resources/Sound/Effect",
				"Resources/Sound",      //音乐系统存放音乐素材
                "Resources/Images",     //对话编辑器图片资源
                "Scripts",
				"Scripts/UI/Panel",     //UI系统附带脚本
                "Scripts/UI/Dialog",
				"Scripts/UI/Overlay",
				"Scripts/UI/Box",
				"Scripts/Logic",
				"Scripts/Scenes",
				"Tools",				//工具
			};


			for (int i = 0; i < frameworkDir.Length; i++) {

				string path = Application.dataPath + "/" + frameworkDir [i];

				if (!Directory.Exists (path)) {
					Directory.CreateDirectory (path);
				}
			}
			AssetDatabase.Refresh ();

		}


		[MenuItem ("Assets/Framework/TestButton")]
		static void TestButton ()
		{

			//Debug.Log (CreateAssetBundles.BuildTargetPlatform);
		}
	}
}
