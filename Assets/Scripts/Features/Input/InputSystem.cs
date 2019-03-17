using System;
using Entitas;
using UnityEngine;
using Skylight;
public sealed class InputSystem : IExecuteSystem
{
	readonly Contexts _contexts;
	private Vector2 m_input;

	public InputSystem (Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Execute ()
	{
		//setBurstMode();
		emitInput ();
	}

	//void setBurstMode()
	//{
	//    if (Input.GetKeyDown(KeyCode.B))
	//    {
	//        _contexts.input.isBurstMode = !_contexts.input.isBurstMode;
	//    }
	//}

	void emitInput ()
	{
		m_input.x = InputService.Instance ().GetAxis (KeyMap.Horizontal);
		m_input.y = InputService.Instance ().GetAxis (KeyMap.Vertical);
		//Debug.Log (m_input);
		if (m_input.x > 0.1f || m_input.x < -0.1f || m_input.y > 0.1f) {
			//var mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//Debug.Log (m_input);
			InputEntity e = _contexts.input.CreateEntity ();
			e.AddInput (m_input);
		}
	}
}
