using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour {

	public UIHandler uiHandler;

	void Awake() {
		if(uiHandler != null) {
			uiHandler.ShowStats();
		}
	}

	void Update() {
		if(uiHandler != null) {
			if(KeyHandler.IsKeyDown("Inventory_Open")) {
				OpenInventory();
			} else if(KeyHandler.IsKeyDown("GUI_Close")) {
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