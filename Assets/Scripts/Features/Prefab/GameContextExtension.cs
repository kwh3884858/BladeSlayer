using System;
using UnityEngine;
using Entitas;
public static class GameContextExtension
{
	public static GameEntity CreateMainPlayer (this GameContext context, int x, int y)
	{
		GameEntity entity = context.CreateEntity ();
		entity.isMovable = true;
		entity.AddPosition (new Vector2Int (x, y));
		entity.AddAsset ("CharacterPlaceholder");
		return entity;
	}
}

public partial class Contexts
{
	public GameEntity m_player;

	//[Entitas.CodeGeneration.Attributes.PostConstructor]
	//public void InitializePlayerEntity ()
	//{
	//	//game.AddEntityIndex(new PrimaryEntityIndex<GameEntity,int>(
	//	//m_entity,
	//	//game.GetGroup(GameMatcher.AllOf(GameMatcher.Position).NoneOf(GameMatcher.Destroyed)),(entity,comp)=>(comp as )

	//	m_player = game.CreateMainPlayer (0, 0);
	//}
}
