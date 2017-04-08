using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerControl : MonoBehaviour {

	private float refDef = 0.0f;
	private float radius;
	//private bool collTop = false;
	//private bool collRight = false;
	private bool collBottom = false;
	//private bool collLeft = false;
	private Vector2 velocity = Vector2.zero;

	public int accuracy = 5;
	public float gravity = 0.005f;
	public float drag = 0.2f;
	public float maxYVel = 3f;
	public float jumpForce = 0.15f;
	public float moveSpeed = 0.15f;
	public float speedDamping = 0.1f;

	void Start() {
		radius = GetComponent<BoxCollider2D>().bounds.extents.y;
	}

	void FixedUpdate() {
		// Velocity modification
		MoveCharacter();
		CollisionDetection();
		transform.position += new Vector3(velocity.x, velocity.y, transform.position.z);

		// Rotate player
		if(Input.GetAxis("Horizontal") > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		} else if(Input.GetAxis("Horizontal") < 0) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	}

	void CollisionDetection() {
		// Check for collisions
		CollTop();
		CollLeft();
		CollBottom();
		CollRight();
	}

	void CollTop() {
		//collTop = false;
		if(velocity.y >= 0) {
			for(int i = 0; i < accuracy; i++) {
				Vector3 origin = transform.position;
				origin.x += (i - accuracy / 2f) * ((radius * accuracy / 2f) / accuracy - 0.01f) + 0.1f;
				origin.y += radius;
				RaycastHit2D ray = Raycast(origin, Vector2.up, Mathf.Abs(velocity.y));
				if(ray) {
					Vector3 pos = transform.position;
					pos.y = ray.point.y - radius;
					transform.position = pos;
					velocity.y = 0;
					//collTop = true;
				}
			}
		}
	}

	void CollLeft() {
		//collLeft = false;
		if(velocity.x <= 0) {
			for(int i = 0; i < accuracy; i++) {
				Vector3 origin = transform.position;
				origin.y += (i - accuracy / 2f) * ((radius * accuracy / 2f) / accuracy - 0.01f) + 0.1f;
				origin.x -= radius;
				RaycastHit2D ray = Raycast(origin, Vector2.left, Mathf.Abs(velocity.x));
				if(ray) {
					Vector3 pos = transform.position;
					pos.x = ray.point.x + radius;
					transform.position = pos;
					velocity.x = 0;
					//collLeft = true;
				}
			}
		}
	}

	void CollBottom() {
		collBottom = false;
		if(velocity.y <= 0) {
			for(int i = 0; i < accuracy; i++) {
				Vector3 origin = transform.position;
				origin.x += (i - accuracy / 2f) * ((radius * accuracy / 2f) / accuracy - 0.01f) + 0.1f;
				origin.y -= radius;
				RaycastHit2D ray = Raycast(origin, Vector2.down, Mathf.Abs(velocity.y));
				if(ray) {
					Vector3 pos = transform.position;
					pos.y = ray.point.y + radius;
					transform.position = pos;
					velocity.y = 0;
					collBottom = true;
				}
			}
		}
	}

	void CollRight() {
		//collRight = false;
		if(velocity.x >= 0) {
			for(int i = 0; i < accuracy; i++) {
				Vector3 origin = transform.position;
				origin.y += (i - accuracy / 2f) * ((radius * accuracy / 2f) / accuracy - 0.01f) + 0.1f;
				origin.x += radius;
				RaycastHit2D ray = Raycast(origin, Vector2.right, Mathf.Abs(velocity.x));
				if(ray) {
					Vector3 pos = transform.position;
					pos.x = ray.point.x - radius;
					transform.position = pos;
					velocity.x = 0;
					//collRight = true;
				}
			}
		}
	}

	void MoveCharacter() {
		// Vertical
		velocity.y -= gravity;
		if(velocity.y > maxYVel) velocity.y = maxYVel;
		if(Input.GetAxis("Vertical") > 0 && collBottom) velocity.y = jumpForce;

		// Horizontal
		float target = Input.GetAxis("Horizontal") * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, target, ref refDef, speedDamping);
	}

	RaycastHit2D Raycast(Vector2 start, Vector2 dir, float dist) {
		Debug.DrawLine(start, start + (dir * dist), Color.red, 0);
		return Physics2D.Raycast(start, dir, dist);
	}

}