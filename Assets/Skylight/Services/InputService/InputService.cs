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
	/// InputService
	/// 输入服务通过暴露简单的接口隐藏不同设备之间的输入差异
	/// Input services hide input differences between different devices by exposing simple interfaces
	/// 同时输入服务能够通过简单的开关来决定是否开启特定设备的输入
	/// At the same time, InputService can determine whether to 
	/// open the input of a specific device through a simple switch
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

		public void SwitchDeviceInput (DeviceType deviceType, bool isOpen)
		{
			switch (deviceType) {
			case DeviceType.Desktop:

				m_isDesktop = isOpen;

				break;

			case DeviceType.Handheld:
				m_isHandheld = isOpen;
				if (m_isHandheld) {
					ShowUI ();
				} else {
					CloseUI ();
				}
				break;
			}
		}



		void ShowUI ()
		{
			m_inputControl.Show ();

		}

		void CloseUI ()
		{
			m_inputControl.Close ();

		}
	}

}
