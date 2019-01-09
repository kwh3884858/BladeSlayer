using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Skylight
{
	public enum InputType
	{
		UnKnown,
		Vector3,
		Button,

	}

	/// <summary>
	/// Environment type for scene.
	/// 每个场景都场景定一个操作环境
	/// 例如：战斗场景和对话场景，使用的就是一套不同的操作环境。
	/// UI也被归入到一个场景中，场景加载时，根据数据导入需要的UI模块。
	/// </summary>
	public enum Environment
	{
		UI,             //UI场景
		Story,          //故事场景
		Battle,         //战斗场景

	}

	/// <summary>
	/// 输入服务
	/// InputService
	/// 输入服务通过暴露简单的接口隐藏不同设备之间的输入差异
	/// Input services hide input differences between different devices by exposing simple interfaces
	/// 
	/// 在不同的场景中切换的时候，会遇到多个运行的场景调用同一个键位的情况。
	/// 例如在即时战斗中，确定键是作为攻击键的，
	/// 但是在剧情场景中，确定键作为对话键，
	/// 为了能够切换这些场景，框架提供一个*输入环境的栈*
	/// 每次新的环境压入时，都会只相应这个环境的输入请。
	/// 例如，当在游戏中开启菜单时，确定键只会被菜单获取到。
	/// 尽管游戏场景也在运行，但是不会获取到对应的操作。
	/// When switching between different environment, 
	/// you will encounter multiple scenes that call the same key. 
	/// For example, in an battle, 
	/// the key is determined as an attack key, 
	/// but in the scenario environment, the key is determined as a dialog key, 
	/// and in order to be able to switch between these scenes, 
	/// the framework provides a stack of *input environments*. 
	/// Every time a new environment is pushed in, 
	/// it will only be input for this environment. 
	/// For example, when the menu is opened in the game, 
	/// the comfirm button will only be retrieved by the menu. 
	/// Although the game scene is also running, 
	/// it will not get the corresponding operation.
	/// 
	/// </summary>
	/// 
	public class InputService : GameModule<InputService>
	{

		//public DeviceType [] m_openDeviceType = { DeviceType.Desktop, DeviceType.Handheld };

		private InputControl m_inputControl;

		//private bool m_isDesktop = false;
		//private bool m_isHandheld = false;

		/// <summary>
		/// The is environment stack.
		/// 这是环境栈，所有的场景，UI在定义时候，都会有一个对应的环境栈
		/// 注册之前，需要往其中压入对应的栈
		/// </summary>
		private Stack<Environment> m_environment = new Stack<Environment> ();


		public InputControl Input {
			get {
				return m_inputControl;
			}
		}

		public InputControl GetInput (Environment environment)
		{
			return m_inputControl;
		}
		/// <summary>
		/// Pushing a the environment into stack，
		/// you need to judge whether the top of stack is already the same type
		/// If it is the same type, it is not pushed onto the stack
		/// 推入一个环境类型，需要判断最上层是否已经是相同的类型。
		/// 如果是相同类型，则不推入栈中
		/// </summary>
		/// <param name="environment">Environment.环境类型</param>
		public void PushEnvironment (Environment environment)
		{

		}

		/// <summary>
		/// Poping a environment type out stack.
		/// 
		/// </summary>
		/// <param name="environment">Environment.环境类型</param>
		public void PopEnvironment (Environment environment)
		{

		}
		public override void SingletonInit ()
		{
			base.SingletonInit ();

			//SwitchDeviceInput (DeviceType.Desktop, true);
			//让移动模块来决定自己需要的是哪一种输出
			m_inputControl = new InputControl ();
			//初始化的时候会把电脑端的操作开启，并且没有提供特别的对应桌面的输入关闭
			m_inputControl.Init ();
		}

		/// <summary>
		/// Switchs the device input.(deprecated)
		/// 切换输入类型。被弃用。不要使用它。
		/// </summary>
		/// <param name="deviceType">Device type.</param>
		/// <param name="isOpen">If set to <c>true</c> is open.</param>
		//public void SwitchDeviceInput (DeviceType deviceType, bool isOpen)
		//{
		//	switch (deviceType) {
		//	case DeviceType.Desktop:

		//		m_isDesktop = isOpen;

		//		break;

		//	case DeviceType.Handheld:
		//		m_isHandheld = isOpen;
		//		//if (m_isHandheld) {
		//		//	ShowUI ();
		//		//} else {
		//		//	CloseUI ();
		//		//}
		//		break;
		//	}
		//}



		//void ShowUI ()
		//{
		//	m_inputControl.Show ();

		//}

		//void CloseUI ()
		//{
		//	m_inputControl.Close ();

		//}
	}

}
