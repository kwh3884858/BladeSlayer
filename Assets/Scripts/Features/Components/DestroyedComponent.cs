using Entitas;
using Entitas.CodeGeneration.Attributes;
[Player]
[Event (EventTarget.Self), Cleanup (CleanupMode.DestroyEntity)]
public sealed class DestroyedComponent : IComponent
{
}
