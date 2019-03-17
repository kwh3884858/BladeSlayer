using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
[Player]
[Event (EventTarget.Self)]
public sealed class PositionComponent : IComponent
{
	public Vector2Int value;
}
