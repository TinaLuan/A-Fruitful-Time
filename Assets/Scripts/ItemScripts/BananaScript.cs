using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour {

	public GameObject banana;

	void OnTriggerEnter(Collider collidingObject) {
		ItemManager.setPlayerSpeedDown();
		Destroy(banana);
	}
}