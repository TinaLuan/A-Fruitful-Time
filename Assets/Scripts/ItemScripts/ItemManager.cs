using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	// TextView showing current item effect. 
	public Text itemText;

	// Timers for each fruit item effect.
	private static float appleTimer = 0F;
	private static float bananaTimer = 0F;
	private static bool isKiwi = false;
	private static bool isPear = false;
	private static bool isStrawberry = false;

	// Standard timer for all items.
	private static float standardTimer = 5F;

	// Bonus time added for respective items.
	private static float strawberryBonus = 5F;
	private static float kiwiBonus = 10F;

	// Used to determine which speed effect to apply.
	private static bool speedUp = false;
	private static bool speedDown = false;

	// Sets a speed up/down and its timer.
	public static void setPlayerSpeedUp() {
		ItemEffectManager.resetPlayerSpeed();
		setAppleTimer();
		speedUp = true;
		speedDown = false;
	}
	public static void setPlayerSpeedDown() {
		ItemEffectManager.resetPlayerSpeed();
		setBananaTimer();
		speedUp = false;
		speedDown = true;
	}

	 // Respective item has been picked up and its timer starts.
	public static void setAppleTimer() {
		appleTimer = standardTimer;
	}
	public static void setBananaTimer() {
		bananaTimer = standardTimer;
	}
	public static void setKiwiTimer() {
		isKiwi = true;
	}
	public static void setPearTimer() {
		isPear = true;
	}
	public static void setStrawberryTimer() {
		isStrawberry = true;
	}

	/*
	 * Checks whether any item has been picked up,
	 * applies the effect of the item and if applicable,
	 * reduces the remaining duration of item timers.
	 */
	public static void checkItems() {
		if (speedUp) {
			if ((int)appleTimer == 0) {
				speedUp = false;
				ItemEffectManager.resetPlayerSpeed();
				//itemText.text = "Timer: " + (int) appleTimer;
			} else {
				ItemEffectManager.applyApple();
				appleTimer -= Time.deltaTime;
			}
		}
		if (speedDown) {
			if ((int)bananaTimer == 0) {
				speedDown = false;
				ItemEffectManager.resetPlayerSpeed();
				//itemText.text = "Timer: " + (int) appleTimer;
			} else {
				ItemEffectManager.applyBanana();
				bananaTimer -= Time.deltaTime;
			}
		}
		if (isKiwi) {
			isKiwi = false;
			ItemEffectManager.applyKiwi(kiwiBonus);
		}
		if (isPear) {
			isPear = false;
			ItemEffectManager.applyPear();
		}
		if (isStrawberry) {
			isStrawberry = false;
			ItemEffectManager.applyStrawberry(strawberryBonus);
		}
	}
}