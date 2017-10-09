using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemEffectManager : MonoBehaviour {

	// Different player speeds.
	private static float normalSpeed = 1F;
	private static float fastSpeed = 2F;
	private static float slowSpeed = 0.5F;

	/* 
	 * Methods applying item effects,
	 * until duration finishes or effect is refreshed.
	 */
	public static void resetPlayerSpeed() {
		PlayerScript.setPlayerSpeed(PlayerScript.getDefaultPlayerSpeed()*normalSpeed);
	}

	public static void applyApple() {
		PlayerScript.setPlayerSpeed(PlayerScript.getDefaultPlayerSpeed()*fastSpeed);
	}

	public static void applyBanana() {
		PlayerScript.setPlayerSpeed(PlayerScript.getDefaultPlayerSpeed()*slowSpeed);
	}

	public static void applyKiwi(float kiwiBonus) {
		TimerScript.addTimerCount(kiwiBonus);
	}

	public static void applyPear() {
		SceneManager.LoadScene("GameWon");
	}

	public static void applyStrawberry(float strawberryBonus) {
		TimerScript.addTimerCount(strawberryBonus);
	}
}