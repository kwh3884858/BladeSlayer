using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skylight;
using UnityEngine.EventSystems;

public class UIDirectionButtonPanel : UIPanel
{

	Transform m_leftButton;
	Transform m_rightButton;
	// Use this for initialization
	void Start ()
	{
		m_leftButton = transform.Find ("LeftButton");
		m_rightButton = transform.Find ("RightButton");

		AddEventTriggerListener (transform.Find ("LeftButton").gameObject,
		EventTriggerType.PointerDown, (BaseEventData obj) => {
			Debug.Log ("left button down");
			EventManager.Instance ().SendEvent<ButtonDownEvent> (new ButtonDownEvent ("A"));
		});

		AddEventTriggerListener (transform.Find ("LeftButton").gameObject,
	EventTriggerType.PointerUp, (BaseEventData obj) => {
		EventManager.Instance ().SendEvent<ButtonUpEvent> (new ButtonUpEvent ("A"));
	});

		AddEventTriggerListener (transform.Find ("RightButton").gameObject,
	EventTriggerType.PointerDown, (BaseEventData obj) => {
		EventManager.Instance ().SendEvent<ButtonDownEvent> (new ButtonDownEvent ("D"));
	});

		AddEventTriggerListener (transform.Find ("RightButton").gameObject,
	EventTriggerType.PointerUp, (BaseEventData obj) => {
		EventManager.Instance ().SendEvent<ButtonUpEvent> (new ButtonUpEvent ("D"));
	});

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void EventPointerDown (UnityEngine.EventSystems.BaseEventData obj)
	{

	}




}
