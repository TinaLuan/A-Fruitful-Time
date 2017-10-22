using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	// Game timer (in seconds).
	private static float timerCount = 0;

	public static void setTimerCount(float newTimer) {
		timerCount = newTimer;
	}

	public static float getTimerCount() {
		return timerCount;
	}

	// TextView to show the game timer.
	public Text timerText;

	void Start() {
		timerCount = OptionsController.difficultySlider.value;
	}

	// Reduces timer until finished
	void Update() {
		reduceTimer();
		isTimerFinished();
	}

	// Reduces the game timer.
	private void reduceTimer() {
		timerCount -= Time.deltaTime;
		timerText.text = "Timer: " + (int) timerCount;
	}

	// When the timer has finished, transition to a "Game Over" scene.
	private void isTimerFinished() {
		if ((int)timerCount == 0) {
			SceneManager.LoadScene("GameEnded");
		}
	}

	// Adds bonus time to timerCount when the appropriate item is picked up.
	public static void addTimerCount(float bonusTime) {
		timerCount += bonusTime;
	}
}