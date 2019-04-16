﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Skylight
{

	[CustomEditor (typeof (GameRoot))]
	public class FrameworkIntroduction : Editor
	{

		override public void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();
			EditorGUILayout.BeginVertical ();
			EditorGUILayout.LabelField ("Scene Editor");
			EditorGUILayout.LabelField ("编辑游戏中的场景后，在Window/SceneEditorWindow中");
			EditorGUILayout.LabelField ("重新添加所需要的场景,这会自动生成Lookup");
			EditorGUILayout.LabelField ("再回到GameRoot中添加所需场景");


			EditorGUILayout.EndVertical ();
		}
	}
}