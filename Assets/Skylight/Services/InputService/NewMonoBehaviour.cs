using UnityEngine;
using System.Collections;

namespace Skylight
{
	public class DesktopPauseInput : BaseButtonInput
	{

		public DesktopPauseInput ()
		{
			this.m_deviceType = DeviceType.Desktop;

		}

		public override bool Value {
			get {

				return Input.GetButton ("Cancel");
			}
		}
	}
}