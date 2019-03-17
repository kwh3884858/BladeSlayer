using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem<PlayerEntity>, IInitializeSystem
{
	readonly Transform _parent;
	//readonly PlayerEntity m_PlayerEntity;
	readonly Contexts m_contexts;

	public AddViewSystem (Contexts contexts) : base (contexts.player)
	{
		_parent = new GameObject ("Views").transform;
		m_contexts = contexts;
	}

	public void Initialize ()
	{
		m_contexts.m_player = m_contexts.player.CreateMainPlayer (0, 0);

	}

	protected override ICollector<PlayerEntity> GetTrigger (IContext<PlayerEntity> context)
		=> context.CreateCollector (PlayerMatcher.Asset);

	protected override bool Filter (PlayerEntity entity) => entity.hasAsset && !entity.hasView;

	protected override void Execute (List<PlayerEntity> entities)
	{
		foreach (var e in entities) {
			e.AddView (instantiateView (e));
		}
	}

	IView instantiateView (PlayerEntity entity)
	{
		GameObject prefab = Skylight.PrefabManager.Instance ().LoadPrefab (entity.asset.value);
		IView view = Object.Instantiate (prefab, _parent).GetComponent<IView> ();
		//var prefab = Resources.Load<GameObject> (entity.asset.value);
		//var view = Object.Instantiate (prefab, _parent).GetComponent<IView> ();
		view.Link (entity);
		return view;
	}
}
