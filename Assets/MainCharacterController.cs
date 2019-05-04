using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skylight;
public class MainCharacterController : MonoBehaviour
{
	public float m_moveSpeed = 1f;

	private bool m_isOldFaceRight = false;
	private bool m_isFaceRight = false;

	Animator m_animator;
	// Use this for initialization
	void Start ()
	{
		m_animator = transform.Find ("Role").GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate ()
	{
		float horizontalAxis = InputService.Instance ().GetAxis (KeyMap.Horizontal);
		if (horizontalAxis > 0.1f || horizontalAxis < -0.1f) {
			Debug.Log (InputService.Instance ().GetAxis (KeyMap.Horizontal));
			transform.localPosition = new Vector3 (
				transform.localPosition.x + horizontalAxis * m_moveSpeed * Time.fixedDeltaTime,
				transform.localPosition.y,
				transform.localPosition.z);


		}
		m_animator.SetFloat ("HorizontalVelocity", Mathf.Abs (horizontalAxis));

		if (horizontalAxis < -0.1f) {
			m_isFaceRight = false;
		}
		if (horizontalAxis > 0.1f) {
			m_isFaceRight = true;
		}

		if (m_isFaceRight != m_isOldFaceRight) {

			transform.localScale = new Vector3 (
			 -transform.localScale.x,
			 transform.localScale.y,
			 transform.localScale.z);
			m_isOldFaceRight = m_isFaceRight;

		}
	}
}
