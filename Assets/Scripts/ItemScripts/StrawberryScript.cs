using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryScript : MonoBehaviour {

	public GameObject strawberry;

	void OnTriggerEnter(Collider collidingObject) {
		ItemManager.setStrawberryTimer();
		Destroy(strawberry);
	}
}