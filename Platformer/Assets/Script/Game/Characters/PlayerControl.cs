using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerControl : MovingObject {
	
	public float jumpForce = 0.15f;
	public float moveSpeed = 0.15f;
	public float speedDamping = 0.1f;

	public override void FixedUpdateMovement() {
		// Vertical
		if(Input.GetAxis("Vertical") > 0 && base.collBottom) velocity.y = jumpForce;

		// Horizontal
		float target = Input.GetAxis("Horizontal") * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, target, ref refDef, speedDamping);
		base.FixedUpdateMovement();
	}

}