using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MenuHandledBase {

	public AudioClip selectSound;
	public AudioClip activateSound;
	public Text back;

	private SoundHandler audioHandler;

	public override void PopulateMenu() {
		audioHandler = GetComponent<SoundHandler>();
		
		AddOption(back, OnBack);
	}

	public override void OnSelectOption(int option) {
		audioHandler.PlaySound(selectSound);
	}

	public override void OnActivateOption(int option) {
		audioHandler.PlaySound(activateSound);
	}

	public void OnBack() {
		GetHandler().SetMenu(0);
	}

}