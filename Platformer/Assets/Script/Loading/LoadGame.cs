using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	public Texture2D loadingBarEmpty;
	public Texture2D loadingBarFull;

	private AsyncOperation asyncC;

	void Start() {
		StartCoroutine(LoadLevel(2));
		print("Load game...");
	}

	IEnumerator LoadLevel(int id) {
		asyncC = SceneManager.LoadSceneAsync(id);
		yield return asyncC;
	}

	void OnGUI() {
		if(asyncC != null) {
			GUI.DrawTexture(new Rect(20, 20, 300, 25), loadingBarEmpty);
			GUI.DrawTexture(new Rect(20, 20, 300 * asyncC.progress, 25), loadingBarFull);
		}
	}

}