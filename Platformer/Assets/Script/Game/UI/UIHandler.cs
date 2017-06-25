using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour {

	private List<GameObject> elements;

	public GameObject stats;
	public GameObject inventory;

	void Init() {
		elements = new List<GameObject>();

		elements.Add(stats);
		elements.Add(inventory);
	}

	public void ShowStats() {
		HideElements();
		ShowElement(stats);
	}

	public void ShowInventory() {
		HideElements();
		ShowElement(inventory);
	}

	private void HideElements() {
		if(elements == null) {
			Init();
		}
		foreach(GameObject element in elements) {
			if(element != null) {
				element.SetActive(false);
			}
		}
	}

	private void ShowElement(GameObject element) {
		if(elements == null) {
			Init();
		}
		if(element != null) {
			element.SetActive(true);
		}
	}

}