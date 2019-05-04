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

	bool m_isAttack;

	public void FinishAttckAnimation ()
	{
		m_animator.SetBool ("IsLightAttack", false);
		m_isAttack = false;
	}

	// Use this for initialization
	void Start ()
	{
		m_animator = transform.Find ("Role").GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (m_isAttack == true) return;

		if (InputService.Instance ().GetInput (KeyMap.LightAttack)) {
			Debug.Log ("Light attack!");
			m_animator.SetBool ("IsLightAttack", true);
			m_isAttack = true;
		}

		if (InputService.Instance ().GetInput (KeyMap.HeavyAttack)) {
			Debug.Log ("Heavy attack!");
			m_isAttack = true;

		}
	}

	void FixedUpdate ()
	{
		if (m_isAttack) return;

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
