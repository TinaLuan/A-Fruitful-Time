using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	// TextView showing current item effect. 
	public static Text itemText;

	// Panel containing the above TextView.
	public static Image itemPanel;

	// Timers for each fruit item effect.
	private static float appleTimer;
	private static float bananaTimer;
	private static float bonusTimer;
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
		isKiwi = false;
		isStrawberry = false;
	}
	public static void setPlayerSpeedDown() {
		ItemEffectManager.resetPlayerSpeed();
		setBananaTimer();
		speedUp = false;
		speedDown = true;
		isKiwi = false;
		isStrawberry = false;
	}

	// Respective item has been picked up and its timer starts.
	public static void setAppleTimer() {
		appleTimer = standardTimer;
	}
	public static void setBananaTimer() {
		bananaTimer = standardTimer;
	}
	public static void setBonusTimer() {
		bonusTimer = standardTimer;
	}
	public static void setKiwiTimer() {
		setBonusTimer();
		speedUp = false;
		speedDown = false;
		isKiwi = true;
		isStrawberry = false;
	}
	public static void setPearTimer() {
		isPear = true;
	}
	public static void setStrawberryTimer() {
		setBonusTimer();
		speedUp = false;
		speedDown = false;
		isKiwi = false;
		isStrawberry = true;
	}

	void Start() {
		// Resets all timers.
		appleTimer = 0F;
		bananaTimer = 0F;
		bonusTimer = 0F;

		// Finds the item text object.
		itemText = GameObject.Find("ItemText").GetComponent<Text>();

		// Finds the item panel object.
		itemPanel = GameObject.Find("ItemPanel").GetComponent<Image>();
		itemPanel.color = new Color(255,255,255,0);
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
				itemText.text = "";
				itemPanel.color = new Color(255,255,255,0);
			} else {
				ItemEffectManager.applyApple();
				appleTimer -= Time.deltaTime;
				itemText.text = "Increased Speed!";
				itemPanel.color = new Color(255,255,255,255);
			}
		} else if ((int) appleTimer != 0) {
			ItemEffectManager.applyApple();
			appleTimer -= Time.deltaTime;
			if ((int)appleTimer == 0) {
				ItemEffectManager.resetPlayerSpeed();
			}
		}
		if (speedDown) {
			if ((int)bananaTimer == 0) {
				speedDown = false;
				ItemEffectManager.resetPlayerSpeed();
				itemText.text = "";
				itemPanel.color = new Color(255,255,255,0);
			} else {
				ItemEffectManager.applyBanana();
				bananaTimer -= Time.deltaTime;
				itemText.text = "Reduced Speed!";
				itemPanel.color = new Color(255,255,255,255);
			}
		} else if ((int) bananaTimer != 0) {
			ItemEffectManager.applyBanana();
			bananaTimer -= Time.deltaTime;
			if ((int)bananaTimer == 0) {
				ItemEffectManager.resetPlayerSpeed();
			}
		}
		if (isKiwi) {
			if ((int)bonusTimer == 0) {
				isKiwi = false;
				itemText.text = "";
				itemPanel.color = new Color(255,255,255,0);
			} else if ((int)bonusTimer == 5) {
				ItemEffectManager.applyKiwi(kiwiBonus);
				itemText.text = "Bonus 10 seconds!";
				itemPanel.color = new Color(255,255,255,255);
			}
			bonusTimer -= Time.deltaTime;
		}
		if (isPear) {
			isPear = false;
			ItemEffectManager.applyPear();
		}
		if (isStrawberry) {
			if ((int)bonusTimer == 0) {
				isStrawberry = false;
				itemText.text = "";
				itemPanel.color = new Color(255,255,255,0);
			} else if ((int)bonusTimer == 5) {
				ItemEffectManager.applyStrawberry(strawberryBonus);
				itemText.text = "Bonus 5 seconds!";
				itemPanel.color = new Color(255,255,255,255);
			}
			bonusTimer -= Time.deltaTime;
		}
	}
}