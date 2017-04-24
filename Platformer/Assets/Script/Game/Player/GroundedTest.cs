using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedTest : MonoBehaviour {

	public bool grounded = false;

	public void OnTriggerStay2D() {
		grounded = true;
	}

	public void OnTriggerExit2D() {
		grounded = false;
	}

}