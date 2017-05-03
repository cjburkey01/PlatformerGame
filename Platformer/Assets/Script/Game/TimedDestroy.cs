using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour {

	public float alarmInSecs;
	public int percent;
	private float current = 0.0f;

	void Update() {
		current += Time.deltaTime;
		percent = Mathf.RoundToInt((current * 100f) / alarmInSecs);
		if(current >= alarmInSecs) Destroy(gameObject);
	}

}