using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable {

	private EnumFacing direction = EnumFacing.RIGHT;
	private Rigidbody2D rb;
	private Vector2 prevPos;
	private Vector3 vel;
	private float zero = 0;
	private bool jump = false;

	public float horizontalSpeed = 1.0f;
	public float horizontalDamping = 0.1f;
	public float jumpForce = 1.25f;
	public Weapon inHand;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		inHand.ammo = 20;
	}

	void Update() {
		// Rotation
		if(Input.GetKeyDown(KeyHandler.GetKey("Up"))) direction = EnumFacing.UP;
		if(Input.GetKey(KeyHandler.GetKey("Left"))) direction = EnumFacing.LEFT;
		else if(Input.GetKey(KeyHandler.GetKey("Right"))) direction = EnumFacing.RIGHT;
		if(direction.Equals(EnumFacing.LEFT)) transform.rotation = Quaternion.Euler(0, 180, 0);
		else if(direction.Equals(EnumFacing.RIGHT)) transform.rotation = Quaternion.Euler(0, 0, 0);

		// Jump
		if(Input.GetKeyDown(KeyHandler.GetKey("Jump"))) jump = true;

		// Shoot
		if(Input.GetKeyDown(KeyHandler.GetKey("Primary"))) {
			Vector3 dir = new Vector3(1, 0, 0);
			switch(direction) {
			case EnumFacing.LEFT:
				dir = new Vector3(-1, 0, 0);
				break;
			case EnumFacing.RIGHT:
				dir = new Vector3(1, 0, 0);
				break;
			case EnumFacing.UP:
				dir = new Vector3(0, 1, 0);
				break;
			default:
				break;
			}
			inHand.Shoot(dir, 100);
		}
	}

	new void FixedUpdate() {
		base.FixedUpdate ();
		vel = rb.velocity;
		Move();
		rb.velocity = vel;
	}

	void Move() {
		// Left/Right
		float raw = 0;
		if(Input.GetKey(KeyHandler.GetKey("Right"))) raw = 1.0f;
		if(Input.GetKey(KeyHandler.GetKey("Left"))) raw = -1.0f;
		raw *= horizontalSpeed;
		vel.x = Mathf.SmoothDamp(vel.x, raw, ref zero, horizontalDamping);

		// Jump
		if(jump) {
			jump = false;
			if(IsGrounded()) vel.y = jumpForce;
		}

		// Height-based Death
		if(transform.position.y <= -10) SetHealth(0);
	}

	void OnTriggerEnter2D(Collider2D c) {
		CheckDamage(c);
	}

	void CheckDamage(Collider2D c) {
		Damager dmgr = c.gameObject.GetComponent<Damager>();
		if(dmgr != null) SetHealth(GetHealth() - dmgr.damageDone);
	}

	bool IsGrounded() {
		GroundedTest gt = GetComponentInChildren<GroundedTest>();
		if(gt != null) return gt.grounded;
		return false;
	}

	public override void OnDeath() {
		vel = Vector3.zero;
		transform.position = new Vector3(0, 3, 0);
		Reset();
	}

}