using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour {

	public UIHandler uiHandler;
	private bool inventoryOpen;

	void Awake() {
		if(uiHandler != null) {
			uiHandler.ShowStats();
		}
	}

	void Update() {
		if(uiHandler != null) {
			bool open = KeyHandler.IsKeyDown("Inventory_Open");
			bool close = KeyHandler.IsKeyDown("GUI_Close");
			if(open && !inventoryOpen) {
				inventoryOpen = true;
				OpenInventory();
			} else if((open && inventoryOpen) || (open || close)) {
				inventoryOpen = false;
				CloseInventory();
			}
		}
	}

	public void OpenInventory() {
		uiHandler.ShowInventory();
	}

	public void CloseInventory() {
		uiHandler.ShowStats();
	}

}