using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour {

	public MenuHandledBase[] menus;
	private int current;

	void Awake() {
		foreach(MenuHandledBase menu in menus) if(menu != null) menu.Init(this);
		SetMenu(0);
	}

	void UpdateMenu() {
		ShowMenus(false);
		EnableMenu(menus[current], true);
		menus[current].Wait();
	}

	void ShowMenus(bool show) {
		foreach(MenuHandledBase menu in menus) if(menu != null) EnableMenu(menu, show);
	}

	void EnableMenu(MenuHandledBase menu, bool enable) {
		if(enable) menu.Enable();
		else menu.Disable();
	}

	public void SetMenu(int menu) {
		current = menu;
		UpdateMenu();
	}

}