using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	// Game timer (in seconds).
	private static float timerCount = 180;

	public static void setTimerCount(float newTimer) {
		timerCount = newTimer;
	}

	public static float getTimerCount() {
		return timerCount;
	}

	// Starts the timer when the player gets off the boat.
	private static bool startTimer = false;

	public static void setStartTimer(bool newStartTimer) {
		startTimer = newStartTimer;
	}

	public static bool getStartTimer() {
		return startTimer;
	}

	// TextView to show the game timer.
	public Text timerText;

	// Reduces timer until finished
	void Update() {
		if (getStartTimer ()) {
			reduceTimer ();
			isTimerFinished ();
		} else {
			timerText.text = "Timer: " + (int) timerCount;
		}
	}

	// Reduces the game timer.
	private void reduceTimer() {
		timerCount -= Time.deltaTime;
		timerText.text = "Timer: " + (int) timerCount;
	}

	// When the timer has finished, transition to a "Game Over" scene.
	private void isTimerFinished() {
		if ((int)timerCount == 0) {
			setTimerCount (180);
			SceneManager.LoadScene("GameEnded");
		}
	}

	// Adds bonus time to timerCount when the appropriate item is picked up.
	public static void addTimerCount(float bonusTime) {
		timerCount += bonusTime;
	}
}