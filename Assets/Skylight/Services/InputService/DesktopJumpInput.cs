using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skylight;
namespace Skylight
{
	public class DesktopJumpInput : BaseButtonInput
	{

		public DesktopJumpInput ()
		{
			this.m_deviceType = DeviceType.Desktop;

		}

		public override bool Value {
			get {

				return Input.GetButtonDown ("Jump");
			}
		}
	}
}