using Entitas;
using Entitas.Unity;
using UnityEngine;

public class MoveController : MonoBehaviour, IVelocityListener
{

	public float m_groundVerticalSpeed = 8f;
	public float m_jumpingVerticalSpeed = 4f;
	public float m_jumpForce = 20f;
	public float m_groundDetectionlength = 0.1f;
	public LayerMask m_layerMask;

	private Rigidbody2D m_rigidbody2D;
	private Collider2D m_collider2D;
	private Vector2 m_leftButton;
	private Vector2 m_centerButton;
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
		m_collider2D = transform.GetComponent<Collider2D> ();
		m_leftButton = m_collider2D.bounds.min;
	}

	public virtual void OnVelocity (GameEntity entity, Vector2 vector)
	{
		m_centerButton = (Vector2)m_collider2D.bounds.min + new Vector2 (m_collider2D.bounds.extents.x, 0);

		RaycastHit2D ray = Physics2D.Raycast (m_centerButton, Vector3.down, m_groundDetectionlength, m_layerMask);
		Debug.DrawRay (m_centerButton, Vector3.down, Color.green);
		if (ray.collider != null) {
			//on ground
			m_rigidbody2D.velocity = new Vector2 (vector.x * m_groundVerticalSpeed,
				vector.y * m_jumpForce);
			return;
		}
		//on air
		//m_rigidbody2D.velocity = vector * m_groundVerticalSpeed;
		m_rigidbody2D.velocity = new Vector2 (vector.x * m_jumpingVerticalSpeed, m_rigidbody2D.velocity.y);
		return;

		//m_rigidbody2D.velocity = new Vector2 (vector.x * m_groundVerticalSpeed, 0);

	}
}
