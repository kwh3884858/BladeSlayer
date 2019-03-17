using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyedListener
{
	public virtual void Link (IEntity entity)
	{
		gameObject.Link (entity);
		PlayerEntity e = (PlayerEntity)entity;
		e.AddPositionListener (this);
		e.AddDestroyedListener (this);

		var pos = e.position.value;
		transform.localPosition = new Vector3 (pos.x, pos.y);
	}

	public virtual void OnPosition (PlayerEntity entity, Vector2Int value)
	{
		transform.localPosition = new Vector3 (value.x, value.y);
	}

	public virtual void OnDestroyed (PlayerEntity entity)
	{
		destroy ();
	}

	protected virtual void destroy ()
	{
		gameObject.Unlink ();
		Destroy (gameObject);
	}
}
