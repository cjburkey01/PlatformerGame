using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public int maxAmmo;
	public int damage;

	private int ammo;
	
	public void Shoot(Vector2 pos, Vector2 dir, float maxDistance) {
		if(ammo > 0) {
			ammo --;
			RaycastHit2D hit = Physics2D.Raycast(pos, dir.normalized, maxDistance);
			if(hit) {
				GameObject objHit = hit.collider.gameObject;
				Destroy (objHit);
			}
		}
	}
}