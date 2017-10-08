using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Based on the tutorial from: https://goo.gl/y7fQin
 * Uses one music file tagged as "EndMusic" to play
 * and loop through in the "end game" scene.
 */ 
public class WinMusic : MonoBehaviour {

	public void Awake() {
		GameObject gameMusic = GameObject.FindGameObjectWithTag("GameMusic");
		Destroy(gameMusic);

		GameObject[] winMusic = GameObject.FindGameObjectsWithTag("WinMusic");
		if (winMusic.Length > 1) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}