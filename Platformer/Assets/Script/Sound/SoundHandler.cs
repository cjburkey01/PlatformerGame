using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour {

	private AudioSource src;

	void Awake() {
		src = GetComponent<AudioSource>();
		if(src == null) src = gameObject.AddComponent<AudioSource>();
	}

	public void PlaySound(AudioClip clip) {
		src.PlayOneShot(clip);
	}

}