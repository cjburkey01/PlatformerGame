using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

	public int health = 100;
	public int damageDone = 100;

	void Update() {
		if (health <= 0)
			Destroy (gameObject);
	}

}