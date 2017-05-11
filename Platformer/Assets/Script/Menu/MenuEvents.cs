using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject optionsMenu;

	void Awake() {
		mainMenu.SetActive(true);
	}

	public void playButtonClick() {
		SceneManager.LoadScene(1);
	}

	public void returnButtonClick() {
		mainMenu.SetActive(true);
		optionsMenu.SetActive(false);
	}

	public void optionsButtonClick() {
		mainMenu.SetActive(false);
		optionsMenu.SetActive(true);
	}

}