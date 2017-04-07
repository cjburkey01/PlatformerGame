using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour {

	private Rigidbody2D rb;
	private bool grounded = false;

	public float gravity = 0.2f;
	public float maxYVel = 20f;
	public float jumpForce = 10f;
	public float moveSpeed = 5.0f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		// Velocity modification
		Vector2 velocity = rb.velocity;
		velocity.y -= gravity;
		if(velocity.y < -maxYVel) velocity.y = -maxYVel;
		velocity.x = Input.GetAxis("Horizontal") * moveSpeed;
		if(Input.GetAxisRaw("Vertical") > 0 && grounded) { rb.AddForce(new Vector2(0, jumpForce)); }
		rb.velocity = velocity;

		// Rotate player
		if(Input.GetAxis("Horizontal") > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		} else if(Input.GetAxis("Horizontal") < 0) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	}

	void OnCollisionStay2D(Collision2D c) {
		if(c.gameObject.tag.Equals("Floor")) {
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D c) {
		grounded = false;
	}

}