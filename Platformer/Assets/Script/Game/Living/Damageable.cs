using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

	public int startingHealth;
	private int health;
	private bool alerted = false;

	void Awake() {
		Reset();
	}

	protected void FixedUpdate() {
		if(health <= 0 && !alerted) {
			alerted = true;
			OnDeath();
		}
	}

	public void SetHealth(int amt) {
		print (amt);
		health = amt;
	}

	public int GetHealth() {
		return health;
	}

	public void Reset() {
		health = startingHealth;
		alerted = false;
	}

	public virtual void OnDeath() {
		Destroy(gameObject);
	}

}