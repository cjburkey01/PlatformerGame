using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : DroppedItem {

	public int amount = 20;

	public override string GetDisplayName() {
		return "Ammo";
	}

	public override void OnPlayerCollect(Player player) {
		player.inHand.ammo += amount;
	}

}