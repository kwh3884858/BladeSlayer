using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ProcessInputSystem : ReactiveSystem<InputEntity>
{
	readonly Contexts _contexts;

	public ProcessInputSystem (Contexts contexts) : base (contexts.input)
	{
		_contexts = contexts;
	}

	protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
		=> context.CreateCollector (InputMatcher.Input);

	protected override bool Filter (InputEntity entity) => entity.hasInput;

	protected override void Execute (List<InputEntity> entities)
	{
		InputEntity inputEntity = entities.SingleEntity ();
		InputComponent input = inputEntity.input;
		//change value is uselesss
		//must change use component generated method
		_contexts.m_player.ReplaceVelocity (input.value);

		//UnityEngine.Debug.Log (input.value);
		//var e = _contexts.game.GetPieceWithPosition(input.value);
		//if (e != null && e.isInteractive)
		//{
		//    e.isDestroyed = true;
		//}
	}
}
