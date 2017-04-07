using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject obj;
	public float damping = 0.3f;
	public float zoomDamping = 0.5f;
	public float defaultZoom = 5f;
	public float movingZoom = 10f;

	private float zoom = 5f;
	private Vector3 vel = Vector3.zero;
	private float r = 0f;

	void FixedUpdate() {
		// Smooth Movement
		Vector3 toPos = obj.transform.position;
		toPos.z = -10;
		transform.position = Vector3.SmoothDamp(transform.position, toPos, ref vel, damping);

		// Smooth Zoom
		float targetZoom = defaultZoom;
		if(obj.GetComponent<Rigidbody2D>() != null) {
			Vector3 vel = obj.GetComponent<Rigidbody2D>().velocity;
			if(vel.x != 0 || vel.y != 0 || vel.z != 0) {
				targetZoom = movingZoom;
			}
		}
		GetComponent<Camera>().orthographicSize = Mathf.SmoothDamp(zoom, targetZoom, ref r, zoomDamping);
	}

}