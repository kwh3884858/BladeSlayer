using System;
using Entitas;
using UnityEngine;
using Skylight;
public sealed class InputSystem : IExecuteSystem
{
	readonly Contexts _contexts;

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
		float input = Skylight.InputService.Instance ().GetAxis (KeyMap.Horizontal);

		if (input >= 0.1f || input <= -0.1f) {
			//var mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			InputEntity e = _contexts.input.CreateEntity ();
			e.AddInput (new Vector2 (
				input,
				0
			));
		}
	}
}
