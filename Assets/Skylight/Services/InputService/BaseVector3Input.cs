using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skylight
{
	public class BaseVector3Input : BaseInput
	{
		public BaseVector3Input ()
		{
			m_inputType = InputType.Vector3;
		}
		//from -1 to 1
		protected Vector3 m_value;

		public virtual Vector3 Value {
			get {
				return m_value;
			}
			set {
				m_value = value;
			}
		}



	}

}
