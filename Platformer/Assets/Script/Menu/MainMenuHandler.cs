using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MenuBase {

	public Text playGame;
	public Text options;
	public Text credits;
	public Text quitGame;

	public override void PopulateMenu() {
		AddOption(playGame, OnPlayGame);
		AddOption(options, OnOptions);
		AddOption(credits, OnCredits);
		AddOption(quitGame, OnQuitGame);
	}

	public void OnPlayGame() {
		print("Play");
		SceneManager.LoadScene(1);
	}

	public void OnOptions() {
		print("Options");
		// TODO: OPTIONS MENU
	}

	public void OnCredits() {
		print("Credits");
		// TODO: CREDITS SCREEN
	}

	public void OnQuitGame() {
		print("Quit");
		Application.Quit();
	}

}