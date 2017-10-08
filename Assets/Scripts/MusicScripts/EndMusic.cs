using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Based on the tutorial from: https://goo.gl/y7fQin
 * Uses one music file tagged as "EndMusic" to play
 * and loop through in the "end game" scene.
 */ 
public class EndMusic : MonoBehaviour {

	public void Awake() {
		GameObject menuMusic = GameObject.FindGameObjectWithTag("GameMusic");
		Destroy(menuMusic);

		GameObject[] gameMusic = GameObject.FindGameObjectsWithTag("EndMusic");
		if (gameMusic.Length > 1) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}