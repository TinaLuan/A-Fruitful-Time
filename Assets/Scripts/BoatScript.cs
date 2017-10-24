using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour {
	
	private float speed;
	private readonly float defaultSpeed = 10f;

	private bool isMoving;

	// Use this for initialization
	void Start () {
		speed = defaultSpeed;
		isMoving = true;
	}

	// Update is called once per frame
	void Update () {
		
		if (isMoving) {
			this.transform.localPosition += transform.right * speed * Time.deltaTime;
		}

//		if () {
//			isMoving = false;
//		}
	}
}
