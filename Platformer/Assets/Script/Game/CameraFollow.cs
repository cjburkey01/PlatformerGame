using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject obj;
	public float damping = 0.3f;
	public float zoomDamping = 1f;
	public float defaultZoom = 5f;
	public float movingZoom = 50f;

	private float zoom = 5f;
	private float r = 0f;
	private Vector3 vel = Vector3.zero;
	private Vector3 prev = Vector3.zero;

	void FixedUpdate() {
		// Smooth Movement
		Vector3 toPos = obj.transform.position;
		toPos.z = -10;
		transform.position = Vector3.SmoothDamp(transform.position, toPos, ref vel, damping);

		// Smooth Zoom
		float targetZoom = defaultZoom;
		if(!prev.Equals(obj.transform.position)) {
			targetZoom = movingZoom;
			prev = obj.transform.position;
		}
		GetComponent<Camera>().orthographicSize = Mathf.SmoothDamp(zoom, targetZoom, ref r, zoomDamping);
	}

}