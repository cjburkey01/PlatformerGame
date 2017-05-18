using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class DamageVignette : MonoBehaviour {

	public float fadeOutTime = 1f;
	public float intensity = 1f;

	private PostProcessingBehaviour at;
	private float timing = 0f;

	void Awake() {
		at = GetComponent<PostProcessingBehaviour>();
	}

	void Update() {
		if(at != null) {
			if(timing >= 0) timing -= Time.deltaTime;
			if(timing < 0) timing = 0;

			VignetteModel.Settings s = at.profile.vignette.settings;
			s.intensity = intensity * (timing / fadeOutTime);
			at.profile.vignette.settings = s;
		}
	}

	public void TakeDamage() {
		timing = fadeOutTime;
	}

}