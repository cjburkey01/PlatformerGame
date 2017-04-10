using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	private int health = 100;
	private int ammo = 10;

	public void SetHealth(int health) { this.health = health; }
	public void TakeHealth(int health) { this.health -= health; }
	public int GetHealth() { return health; }
	public bool IsDead() { return health <= 0; }

	public void SetAmmo(int ammo) { this.ammo = ammo; }
	public void TakeAmmo(int ammo) { this.ammo -= ammo; }
	public int GetAmmo() { return ammo; }
	public bool OutOfAmmo() { return ammo <= 0; }

}