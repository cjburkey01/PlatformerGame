using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGui : MonoBehaviour {

	public float healthFade = 0.5f;
	public Text healthDisplay;
	public Text ammoDisplay;

	private Player ply;
	private float healthTimer = 0;
	private Color originalColor;

	void Awake() {
		ply = GetComponent<Player>();
		originalColor = healthDisplay.color;
	}

	private float prevHealth;
	void Update() {
		if(ply != null) {
			if(ply.GetHealth() != prevHealth) {
				prevHealth = ply.GetHealth();
				healthTimer = healthFade;
			}

			if(healthTimer > 0) healthTimer -= Time.deltaTime;
			if(healthTimer < 0) healthTimer = 0;

			if(healthTimer > 0) {
				healthDisplay.color = new Color(0.75f, 0f, 0f);
				healthDisplay.fontStyle = FontStyle.Bold;
			} else {
				healthDisplay.color = originalColor;
				healthDisplay.fontStyle = FontStyle.Normal;
			}

			healthDisplay.text = ply.GetHealth() + " HP";
			ammoDisplay.text = ply.inHand.ammo + "";
		}
	}
}