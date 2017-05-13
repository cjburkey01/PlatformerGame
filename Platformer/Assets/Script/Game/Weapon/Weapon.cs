using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public GameObject streak;
	public bool doesTakeAmmo = false;
	public int maxAmmo;
	public int damage;
	public int ammo;
	public float shootDelayInSeconds = 0.5f;
	public string weaponName;
	public string description;

	private float time = 0.0f;

	void Update() {
		time += Time.deltaTime;
	}
	
	public void Shoot(Vector3 dir, float maxDistance) {
		if(ammo > 0 && time >= shootDelayInSeconds) {
			time = 0.0f;
			if(doesTakeAmmo) ammo --;
			Vector3 pos = GetComponentInChildren<BarrelEnd>().GetPos();
			RaycastHit2D hit = Physics2D.Raycast(pos, dir, maxDistance);
			if(hit) {
				Damageable dmgr = hit.collider.GetComponent<Damageable>();
				if (dmgr != null) dmgr.SetHealth(dmgr.GetHealth() - damage);
				Streak(pos, hit.point);
			} else {
				Streak(pos, pos + (dir * maxDistance));
			}
		}
	}

	private void Streak(Vector3 start, Vector3 end) {
		GameObject obj = Instantiate(streak, Vector3.zero, Quaternion.identity);
		StreakController str = obj.GetComponent<StreakController>();
		str.Init();
		str.setStart(start);
		str.setEnd(end);
	}
}