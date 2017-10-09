using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Based on the tutorial from: https://goo.gl/y7fQin
 * Uses one music file tagged as "GameMusic" to play
 * and loop through all the scenes related to gameplay.
 */
public class GameMusic : MonoBehaviour {

	public void Awake() {
		GameObject menuMusic = GameObject.FindGameObjectWithTag("MenuMusic");
		Destroy(menuMusic);

		GameObject[] gameMusic = GameObject.FindGameObjectsWithTag("GameMusic");
		if (gameMusic.Length > 1) {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}