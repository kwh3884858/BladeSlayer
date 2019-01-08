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

	public enum Environment
	{

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
	/// </summary>
	public class InputService : GameModule<InputService>
	{

		public DeviceType [] m_openDeviceType = { DeviceType.Desktop, DeviceType.Handheld };

		InputControl m_inputControl;

		private bool m_isDesktop = false;
		private bool m_isHandheld = false;



		public InputControl Input {
			get {
				return m_inputControl;
			}
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
		public void SwitchDeviceInput (DeviceType deviceType, bool isOpen)
		{
			switch (deviceType) {
			case DeviceType.Desktop:

				m_isDesktop = isOpen;

				break;

			case DeviceType.Handheld:
				m_isHandheld = isOpen;
				//if (m_isHandheld) {
				//	ShowUI ();
				//} else {
				//	CloseUI ();
				//}
				break;
			}
		}



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
