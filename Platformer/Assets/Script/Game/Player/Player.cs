﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	private Rigidbody2D rb;
	private Vector2 prevPos;
	private Vector3 vel;
	private float zero = 0;
	private bool usedVertical = false;
	private bool canJump;

	public float horizontalSpeed = 1.0f;
	public float horizontalDamping = 0.1f;
	public float jumpForce = 1.0f;
	public GameObject jimothy;
	public Weapon inHand;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		inHand.ammo = 20;
	}

	void FixedUpdate() {
		vel = rb.velocity;
		Move();
		rb.velocity = vel;
	}

	void Move() {
		// Left/Right
		float target = Input.GetAxisRaw("Horizontal") * horizontalSpeed;
		vel.x = Mathf.SmoothDamp(vel.x, target, ref zero, horizontalDamping);

		// Jump
		if(Input.GetAxisRaw("Vertical") > 0 && canJump) {
			if(!usedVertical) {
				usedVertical = true;
				vel.y = jumpForce;
			}
		} else {
			usedVertical = false;
		}

		if(IsGrounded() && Input.GetAxisRaw("Vertical") == 0f) {
			canJump = true;
		} else {
			canJump = false;
		}

		// Rotation
		if(prevPos.x < transform.position.x) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		} else if(prevPos.x > transform.position.x) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		prevPos = transform.position;

		if(transform.position.y <= -10){
			transform.position = new Vector3(0, 3, 0);
			
		}

		if(Input.GetKeyDown(KeyCode.X)) {
			inHand.Shoot (inHand.gameObject.transform.position, transform.rotation.eulerAngles, 100);
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.Equals(jimothy)) {
			transform.position = new Vector3(0, 3, 0);
		}
	}

	bool IsGrounded() {
		GroundedTest gt = GetComponentInChildren<GroundedTest>();
		if(gt != null) return gt.grounded;
		return false;
	}

}