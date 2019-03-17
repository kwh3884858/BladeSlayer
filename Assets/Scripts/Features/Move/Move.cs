using Entitas;
using Entitas.Unity;
using UnityEngine;

public class Move : MonoBehaviour, IVelocityListener
{
	public float m_moveSpeed = 1f;
	private Rigidbody2D m_rigidbody2D;

	//public virtual void LinkMove (IEntity entity)
	//{
	//	gameObject.Link (entity);
	//	GameEntity e = (GameEntity)entity;

	//	e.AddVelocityListener (this);

	//	m_rigidbody2D = transform.GetComponent<Rigidbody2D> ();

	//}

	void Start ()
	{
		Contexts.sharedInstance.m_player.AddVelocityListener (this);


		m_rigidbody2D = transform.GetComponent<Rigidbody2D> ();

	}

	public virtual void OnVelocity (GameEntity entity, Vector2 vector)
	{
		m_rigidbody2D.velocity = vector * m_moveSpeed;
	}
}
