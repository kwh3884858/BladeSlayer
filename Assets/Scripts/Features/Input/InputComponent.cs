using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input]
public sealed class InputComponent : IComponent
{
	public Vector2 value;
}
