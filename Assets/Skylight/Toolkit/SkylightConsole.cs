using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skylight;
using UnityEngine.UI;
public class SkylightConsole : UIPanel
{
	Text m_text;

	public bool m_isOpen = false;

	public override void PanelInit ()
	{
		base.PanelInit ();
		m_text = transform.Find ("Panel/Console").GetComponent<Text> ();
		if (m_isOpen == false) {
			transform.Find ("Panel").gameObject.SetActive (false);
		}
	}

	public void Show (string str)
	{
		m_text.text += str;

	}

	public override void PanelClose ()
	{
		base.PanelClose ();
	}
}
