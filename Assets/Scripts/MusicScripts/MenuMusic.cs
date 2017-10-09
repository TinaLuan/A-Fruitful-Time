using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Based on the tutorial from: https://goo.gl/y7fQin
 * Uses one music file tagged as "MenuMusic" to play and loop through 
 * all the other main menu scenes like "Instructions" & "Options".
 */ 
public class MenuMusic : MonoBehaviour {

	public void Awake() {
		GameObject endMusic = GameObject.FindGameObjectWithTag("EndMusic");
		Destroy(endMusic);

		GameObject[] menuMusic = GameObject.FindGameObjectsWithTag("MenuMusic");
		if (menuMusic.Length > 1) {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}