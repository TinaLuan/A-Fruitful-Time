using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiScript : MonoBehaviour {

	public GameObject kiwi;

	void OnTriggerEnter(Collider collidingObject) {
		ItemManager.setKiwiTimer();
		Destroy(kiwi);
	}
}