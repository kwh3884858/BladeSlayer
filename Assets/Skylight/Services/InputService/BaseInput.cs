using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skylight
{
	public class BaseInput
	{
		//public string DeivceType = "";
		protected DeviceType m_deviceType = DeviceType.Unknown;

		protected InputType m_inputType = InputType.UnKnown;



		public virtual DeviceType GetDeviceType ()
		{
			return m_deviceType;
		}



		public virtual InputType GetInputeType ()
		{
			return m_inputType;
		}
	}
}

