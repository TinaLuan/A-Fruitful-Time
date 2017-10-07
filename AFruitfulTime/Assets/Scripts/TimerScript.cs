using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	private static float timerCount = 60;

	//public GameObject target;
	public Text timerText;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.GetInt("highScore",highScore);
        //highScore = PlayerPrefs.GetInt ("highScore", highScore);
	}
	
	// Update is called once per frame
	void Update () {
		timerCount -= Time.deltaTime;
		timerText.text = "Timer: " + (int) timerCount;

		if ((int)timerCount == 0) {
			SceneManager.LoadScene("GameEnded");
		}
	}

	public void endGame() {
		
	}
}