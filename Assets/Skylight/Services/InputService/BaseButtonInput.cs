using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skylight
{
	public class BaseButtonInput : BaseInput
	{
		public BaseButtonInput ()
		{
			m_inputType = InputType.Button;
		}
		//from -1 to 1
		protected bool m_value = false;

		public virtual bool Value {
			get {
				return m_value;
			}
			set {
				m_value = value;
			}
		}


	}

}
