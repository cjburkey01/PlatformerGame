using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour {
	
	public float bobTime = 1.25f;
	public float bobAmp = 0.2f;
	public GameObject background;

	private Vector3 start;
	private GameObject bck;

	void Awake() {
		if(background != null) {
			bck = Instantiate(background, transform.position, Quaternion.identity);
			//bck.transform.parent = transform;
			bck.transform.name = GetDisplayName() + "_Back";
		}
		start = transform.position;
	}

	void Update() {
		Vector3 newPos = transform.position;
		newPos.y = start.y + (bobAmp / 2f) * Mathf.Sin(((2f * Mathf.PI) / bobTime) * Time.time) + (bobAmp / 2f);
		transform.position = newPos;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Player p = collider.gameObject.GetComponent<Player>();
		if(p != null) {
			OnPlayerCollect(p);
			print("Collect: " + GetDisplayName());
			if(bck != null) Destroy(bck);
			Destroy(gameObject);
		}
	}

	public virtual string GetDisplayName() {
		return "Dropped Item";
	}

	public virtual void OnPlayerCollect(Player player) {
		print("Default collection event! Fix this now!");
	}

}