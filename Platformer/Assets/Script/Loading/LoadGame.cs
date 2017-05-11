using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

	public Slider slider;

	private AsyncOperation asyncC;

	void Start() {
		print("Loading game...");
		StartCoroutine(LoadLevel(2));
	}

	IEnumerator LoadLevel(int id) {
		asyncC = SceneManager.LoadSceneAsync(id);
		yield return asyncC;
	}

	void Update() {
		slider.value = asyncC.progress;
	}

}