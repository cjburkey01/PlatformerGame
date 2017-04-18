using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector2 prevPos;
	private Vector3 vel;
	private float zero = 0;
	private bool usedVertical = false;
	private bool grounded = false;

	public float horizontalSpeed = 1.0f;
	public float horizontalDamping = 0.1f;
	public float jumpForce = 1.0f;
	public GameObject jimothy;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		vel = rb.velocity;
		Move();
		rb.velocity = vel;
	}

	void Move() {
		// Rotation
		if(prevPos.x < transform.position.x) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		} else if(prevPos.x > transform.position.x) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		prevPos = transform.position;

		// Left/Right
		float target = Input.GetAxisRaw("Horizontal") * horizontalSpeed;
		vel.x = Mathf.SmoothDamp(vel.x, target, ref zero, horizontalDamping);

		// Jump
		if(Input.GetAxisRaw("Vertical") > 0 && grounded) {
			if(!usedVertical) {
				usedVertical = true;
				vel.y = jumpForce;
			}
		} else {
			usedVertical = false;
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.Equals(jimothy)) {
			transform.position = new Vector3(0, 3, 0);
		}
	}

	void OnCollisionStay2D(Collision2D c) {
		ContactPoint2D cp2d = c.contacts[0];
		if(cp2d.point.y < transform.position.y) {
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D c) {
		grounded = false;
	}

}