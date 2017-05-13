using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGui : MonoBehaviour {

	public Text healthDisplay;
	public Text ammoDisplay;

	private Player ply;

	void Awake() {
		ply = GetComponent<Player>();
	}

	void Update() {
		if(ply != null) {
			healthDisplay.text = ply.GetHealth() + " HP";
			ammoDisplay.text = ply.inHand.ammo + "";
		}
	}
}