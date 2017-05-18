using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MenuHandledBase {

	public AudioClip selectSound;
	public AudioClip activateSound;
	public Text playGame;
	public Text optionsTxt;
	public Text credits;
	public Text quitGame;

	private SoundHandler audioHandler;

	public override void PopulateMenu() {
		audioHandler = GetComponent<SoundHandler>();

		AddOption(playGame, OnPlayGame);
		AddOption(optionsTxt, OnOptions);
		AddOption(credits, OnCredits);
		AddOption(quitGame, OnQuitGame);
	}

	public override void OnSelectOption(int option) {
		audioHandler.PlaySound(selectSound);
	}

	public override void OnActivateOption(int option) {
		audioHandler.PlaySound(activateSound);
	}

	public void OnPlayGame() {
		SceneManager.LoadScene(1);
	}

	public void OnOptions() {
		GetHandler().SetMenu(1);
	}

	public void OnCredits() {
		// TODO: CREDITS SCREEN
	}

	public void OnQuitGame() {
		Application.Quit();
	}

}