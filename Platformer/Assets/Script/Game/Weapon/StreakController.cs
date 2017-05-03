using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreakController : MonoBehaviour {

	private LineRenderer lRen;
	private float existTime = 0.25f;
	private float timeLeft;

	public void Init() {
		lRen = GetComponent<LineRenderer>();
		timeLeft = existTime;
	}

	public void setStart(Vector3 pos) {
		lRen.SetPosition(0, pos);
	}

	public void setEnd(Vector3 pos) {
		lRen.SetPosition(1, pos);
	}

	public float getOpacity() {
		return timeLeft / (existTime * 2);
	}

	void Update() {
		timeLeft -= Time.deltaTime;
		if(timeLeft <= 0) { Destroy(gameObject); return; }
		Color c = lRen.material.GetColor("_TintColor");
		c.a = getOpacity();
		lRen.material.SetColor("_TintColor", c);
	}

}