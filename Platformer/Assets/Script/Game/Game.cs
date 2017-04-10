using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	public PlayerInventory player;
	public Vector2 topLeft;
	public Vector2 bottomRight;

	void Update() {
		if(Input.GetKey(KeyCode.Escape)) Application.Quit();
		if(player.IsDead()) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
	}

}