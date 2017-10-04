using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public int moveSpeed = 3;
	public int cameraSpeed = 400;
	//private float rollSpeed = 40;
	//private float roll = 0.0f;
	private float yaw = 0.0f;
	private float pitch = 0.0f;

	// Use this for initialization
	void Start () {
	}
		
	void onCollisionEnter(Collision col) {
		if (col.gameObject.name == "Edge") {
			
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		// Updates "Forward" Movement
		if (Input.GetKey(KeyCode.W)) {
			this.transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
		}
		// Updates "Backward" Movement
		if (Input.GetKey(KeyCode.S)) {
			this.transform.localPosition -= transform.forward * moveSpeed * Time.deltaTime;
		}

		// Updates "Right" Movement
		if (Input.GetKey (KeyCode.D)) {
			this.transform.localPosition += transform.right * moveSpeed * Time.deltaTime;
		}
		// Updates "Left" Movement
		if (Input.GetKey(KeyCode.A)) {
			this.transform.localPosition -= transform.right * moveSpeed * Time.deltaTime;
		}


		// Updates "Yaw, Pitch, and Roll" Movement
		if (Input.mousePresent) {

			// Updates "Pitch" Movement
			//pitch -= Input.GetAxis ("Mouse Y") * cameraSpeed * Time.deltaTime;


			// Updates "Yaw" Movement
			yaw += Input.GetAxis("Mouse X") * cameraSpeed * Time.deltaTime; 
			/*
			// Updates "Right Roll" Movement
			if (Input.GetKey (KeyCode.Q)) {
				roll += rollSpeed * Time.deltaTime;
			}
			// Updates "Left Roll" Movement
			if (Input.GetKey (KeyCode.E)) {
				roll += -rollSpeed * Time.deltaTime;
			}*/

			// Updates whichever changed
			//this.transform.eulerAngles = new Vector3(pitch, yaw, roll);
			this.transform.eulerAngles = new Vector3(0, yaw, 0);
		}

	}
}
