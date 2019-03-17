using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
[Player]
[Event (EventTarget.Self)]
public class VelocityComponent : IComponent
{
	public Vector2 value;
}
