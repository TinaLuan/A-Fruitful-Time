using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (TimerScript.getTimerCount() == 0) {
			TimerScript.setTimerCount(180);
		}
	}
}