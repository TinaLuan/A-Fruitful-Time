using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearScript : MonoBehaviour {

	public GameObject pear;

	void OnTriggerEnter(Collider collidingObject) {
		ItemManager.setPearTimer();
		Destroy(pear);
	}
}