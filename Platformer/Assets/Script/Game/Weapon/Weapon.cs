using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public GameObject streak;
	public bool doesTakeAmmo = false;
	public int maxAmmo;
	public int damage;
	public int ammo;
	
	public void Shoot(Vector3 dir, float maxDistance) {
		if(ammo > 0) {
			if(doesTakeAmmo) ammo --;
			Vector3 pos = GetComponentInChildren<BarrelEnd>().GetPos();
			RaycastHit2D hit = Physics2D.Raycast(pos, dir, maxDistance);
			if(hit) {
				Damager dmgr = hit.collider.GetComponent<Damager>();
				if (dmgr != null)
					dmgr.health -= damage;
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