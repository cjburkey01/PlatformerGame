using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler {

	private static bool init = false;
	private static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

	public static void Init() {
		if(!init) {
			init = true;
		}
	}

	public static void SetKey(string name, KeyCode key) {
		keys.Add(name, key);
	}

	public static KeyCode GetKey(string name) {
		KeyCode c;
		keys.TryGetValue(name, out c);
		return c;
	}

	public static bool IsKeyPressed(string name) {
		KeyCode c = GetKey(name);
		if(c == KeyCode.None) return false;
		return Input.GetKey(c);
	}

}