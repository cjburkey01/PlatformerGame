using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaEnemy : Damageable {
	
	public Vector3 point1;
	public Vector3 point2;
	public float timeInSeconds;
	public GameObject explosion;
	public GameObject drop;

	private Vector3 origin;
	private Vector3 target;
	private Vector3 prev;
	private float progress = 0;
	private bool flipped = false;

	void Start() {
		SetOriginAndTarget(point1, point2);
	}

	void Update() {
		if(transform.position.Equals(target)) {
			if(flipped) {
				flipped = false;
				SetOriginAndTarget(point1, point2);
			} else {
				flipped = true;
				SetOriginAndTarget(point2, point1);
			}
		}

		progress += Time.deltaTime / timeInSeconds;
		transform.position = Vector2.Lerp(origin, target, progress);

		if(prev.x < transform.position.x) transform.rotation = Quaternion.Euler(0, 0, 0);
		else if(prev.x > transform.position.x) transform.rotation = Quaternion.Euler(0, 180, 0);
		prev = transform.position;
	}

	void SetOriginAndTarget(Vector3 or, Vector3 tar) {
		progress = 0;
		origin = or;
		target = tar;
	}

	public override void OnDeath() {
		Instantiate(explosion, transform.position, Quaternion.identity);
		Instantiate(drop, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
	}

}