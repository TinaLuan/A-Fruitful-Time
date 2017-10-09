using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour {

	public GameObject apple;

	void OnTriggerEnter(Collider collidingObject) {
		ItemManager.setPlayerSpeedUp();
		Destroy(apple);
	}
}