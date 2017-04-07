using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour {

	private Rigidbody2D rb;
	//private BoxCollider2D coll;

	private bool grounded = false;

	public float gravity = 0.2f;
	public float maxYVel = 20f;
	public float jumpForce = 10f;
	public float moveSpeed = 5.0f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		//coll = GetComponent<BoxCollider2D>();
	}

	void Update() {
		Vector2 velocity = rb.velocity;
		velocity.y -= gravity;
		if(velocity.y < -maxYVel) velocity.y = -maxYVel;
		velocity.x = Input.GetAxis("Horizontal") * moveSpeed;
		if(Input.GetAxisRaw("Vertical") > 0 && grounded) { rb.AddForce(new Vector2(0, jumpForce)); }
		rb.velocity = velocity;
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