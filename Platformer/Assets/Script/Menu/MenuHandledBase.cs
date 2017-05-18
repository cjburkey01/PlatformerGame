using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandledBase : MenuBase {

	public RectTransform child;

	private bool onMenu = true;
	private MenuHandler menuHandler;

	public void Init(MenuHandler handler) {
		onMenu = false;
		this.menuHandler = handler;
	}
	
	new void Update() {
		if(onMenu) base.Update();
	}

	public void Enable() {
		onMenu = true;
		child.gameObject.SetActive(true);
		Select(0);
	}

	public void Disable() {
		onMenu = false;
		child.gameObject.SetActive(false);
	}

	protected MenuHandler GetHandler() {
		return menuHandler;
	}

}