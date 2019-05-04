using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
	MainCharacterController m_controller;
	// Use this for initialization
	void Start ()
	{
		m_controller = transform.parent.GetComponent<MainCharacterController> ();

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void LightAnimationFinish ()
	{
		m_controller.FinishAttckAnimation ();
	}
}
