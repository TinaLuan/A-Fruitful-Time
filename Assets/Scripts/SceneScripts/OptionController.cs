using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour {

	public Slider difficulty;
	public static Slider difficultyTimer;

	void Start() {
		difficultyTimer = difficulty;
	}

	public void OnBackButtonPressed() {
		TimerScript.setTimerCount(difficulty.value);
		SceneManager.LoadScene("MainMenu");
	}
}