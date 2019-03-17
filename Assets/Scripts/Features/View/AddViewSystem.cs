using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
	readonly Transform _parent;
	//readonly GameEntity m_gameEntity;
	readonly Contexts m_contexts;

	public AddViewSystem (Contexts contexts) : base (contexts.game)
	{
		_parent = new GameObject ("Views").transform;
		m_contexts = contexts;
	}

	public void Initialize ()
	{
		m_contexts.m_player = m_contexts.game.CreateMainPlayer (0, 0);

	}

	protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
		=> context.CreateCollector (GameMatcher.Asset);

	protected override bool Filter (GameEntity entity) => entity.hasAsset && !entity.hasView;

	protected override void Execute (List<GameEntity> entities)
	{
		foreach (var e in entities) {
			e.AddView (instantiateView (e));
		}
	}

	IView instantiateView (GameEntity entity)
	{
		GameObject prefab = Skylight.PrefabManager.Instance ().LoadPrefab (entity.asset.value);
		IView view = Object.Instantiate (prefab, _parent).GetComponent<IView> ();
		//var prefab = Resources.Load<GameObject> (entity.asset.value);
		//var view = Object.Instantiate (prefab, _parent).GetComponent<IView> ();
		view.Link (entity);
		return view;
	}
}
