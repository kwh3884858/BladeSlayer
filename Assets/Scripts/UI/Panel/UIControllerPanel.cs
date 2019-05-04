using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skylight;
using UnityEngine.EventSystems;

public class UIControllerPanel : UIPanel
{


	public override void PanelInit ()
	{
		base.PanelInit ();

		AddEventTriggerListener (transform.Find ("LightAttack").gameObject,
	EventTriggerType.PointerDown, (BaseEventData obj) => {
		Debug.Log ("left button down");
		EventManager.Instance ().SendEvent<ButtonDownEvent> (new ButtonDownEvent ("J"));
	});

		AddEventTriggerListener (transform.Find ("LightAttack").gameObject,
	EventTriggerType.PointerUp, (BaseEventData obj) => {
		EventManager.Instance ().SendEvent<ButtonUpEvent> (new ButtonUpEvent ("J"));
	});

		AddEventTriggerListener (transform.Find ("HeavyAttack").gameObject,
	EventTriggerType.PointerDown, (BaseEventData obj) => {
		EventManager.Instance ().SendEvent<ButtonDownEvent> (new ButtonDownEvent ("K"));
	});

		AddEventTriggerListener (transform.Find ("HeavyAttack").gameObject,
	EventTriggerType.PointerUp, (BaseEventData obj) => {
		EventManager.Instance ().SendEvent<ButtonUpEvent> (new ButtonUpEvent ("K"));
	});
	}

	public override void PanelOpen ()
	{
		base.PanelOpen ();

	}

	public override void PanelClose ()
	{
		base.PanelClose ();

	}

	void LightAttack ()
	{

	}

	void HeavyAttack ()
	{

	}

}
