using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBase : MonoBehaviour {

	private List<MenuOption> options;
	private int selected;
	private bool wait = true;

	public virtual void PopulateMenu() { print("Override PopulateMenu()!"); }
	public virtual void OnSelectOption(int selected) {  }
	public virtual void OnActivateOption(int selected) {  }

	void Awake() {
		options = new List<MenuOption>();
		PopulateMenu();
		UpdateChoice(false);
	}

	public void Wait() {
		wait = true;
	}

	protected void Update() {
		if(!wait && options != null) {
			if(Input.GetKeyDown(KeyHandler.GetKey("Menu_Down"))) {
				selected++;
				UpdateChoice(true);
			} else if(Input.GetKeyDown(KeyHandler.GetKey("Menu_Up"))) {
				selected--;
				UpdateChoice(true);
			} else if(Input.GetKeyDown(KeyHandler.GetKey("Menu_Submit"))) {
				DoAction();
			}
		} else {
			wait = false;
		}
	}

	void CheckValue() {
		if(options != null) {
			if(selected >= options.Count) selected = 0;
			if(selected < 0) selected = options.Count - 1;
		}
	}

	void DoAction() {
		OnActivateOption(selected);
		DestylizeAll();
		options[selected].Activate();
		options[selected].Call();
	}

	void UpdateChoice(bool update) {
		if(options != null) {
			if(update) OnSelectOption(selected);
			CheckValue();
			DestylizeAll();
			options[selected].Select(true);
		}
	}

	void DestylizeAll() {
		if(options != null) foreach(MenuOption opt in options) opt.Select(false);
	}

	public void AddOption(Text text, MenuOption.OnCall onCall) {
		options.Add(new MenuOption(text, onCall));
	}

	public void Select(int i) {
		selected = i;
		UpdateChoice(false);
	}

	public class MenuOption {
		private string text;
		private Color color;
		private Text textObj;
		private OnCall onCall;

		public MenuOption(Text obj, OnCall onCall) {
			text = obj.text;
			color = obj.color;
			textObj = obj;
			this.onCall = onCall;
		}

		public void Call() {
			onCall();
		}

		public void Select(bool selected) {
			if(selected) {
				textObj.text = "< " + text + " >";
				textObj.color = Color.red;
			} else {
				textObj.text = text;
				textObj.color = color;
			}
		}

		public void Activate() {
			textObj.color = Color.blue;
		}

		public delegate void OnCall();
	}

}