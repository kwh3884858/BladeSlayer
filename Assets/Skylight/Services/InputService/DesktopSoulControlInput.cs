﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skylight;
namespace Skylight
{
	public class DesktopSoulControlInput : BaseButtonInput
	{

		public DesktopSoulControlInput ()
		{
			this.m_deviceType = DeviceType.Desktop;

		}

		public override bool Value {
			get {

				return Input.GetButtonDown ("Key3");
			}
		}
	}
}