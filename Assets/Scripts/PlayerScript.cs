using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private static float timerCount;
	public int moveSpeed;
	private readonly static int defaultMoveSpeed = 3;
	public int cameraSpeed;
	private readonly static int defaultCameraSpeed = 400;
	private float yaw = 0.0f;
	//private float pitch = 0.0f;

	private bool isApple = false;
	private bool isBanana = false;
	private bool isKiwi = false;
	private bool isPear = false;
	private bool isStrawberry = false;


	// Use this for initialization
	void Start () {
		moveSpeed = defaultMoveSpeed;
		cameraSpeed = defaultCameraSpeed;
	}

	public void pickedApple() {

	}

	public void pickedBanana() {

	}

	public void pickedKiwi() {

	}

	public void pickedPear() {

	}

	public void pickedStrawberry() {

	}
		
	// Update is called once per frame
	void FixedUpdate() {

		checkItems();

		playerMovement();
	}

	private void checkItems() {
		if (isApple) {

		}
		if (isBanana) {

		}
		if (isKiwi) {

		}
		if (isPear) {

		}
		if (isStrawberry) {

		}

	}

	private void checkItemTimer() {
		if (isApple) {

		}
		if (isBanana) {

		}
		if (isKiwi) {

		}
		if (isPear) {

		}
		if (isStrawberry) {

		}

	}

	private void playerMovement() {
		
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

			// Updates whichever changed
			this.transform.eulerAngles = new Vector3(0, yaw, 0);
		}
	}

	/*
	void onCollisionEnter(Collision col) {
		if (col.gameObject.name == "Edge") {
			
		}

	}*/
}