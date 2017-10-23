using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	// Player and camera move speed.
	private static float playerSpeed, cameraSpeed;
	private readonly static float defaultPlayerSpeed = 6F;
	private readonly static float defaultCameraSpeed = 400F;

	// Used for player mouse movement.
	private float yaw = 0.0f;
	//private float pitch = 0.0f;
	/*
	private float rotationX = 0F;
	private float rotationY = 0F;
	private float sensitivityX = 15F;
	private float sensitivityY = 15F;
	private float minimumX = -20F;
	private float maximumX = 20F;
	private float minimumY = -20F;
	private float maximumY = 20F;*/

	// Setters and getters to be used from other classes.
	public static float getDefaultPlayerSpeed() {
		return defaultPlayerSpeed;
	}
	public static void setPlayerSpeed(float newPlayerSpeed) {
		playerSpeed = newPlayerSpeed;
	}
	public static void setCameraSpeed(float newCameraSpeed) {
		cameraSpeed = newCameraSpeed;
	}

	// Initialises default player and camera move speed.
	void Start () {
		// Limits fps to 60.
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;

		// Sets the default player & camera speed.
		setPlayerSpeed(defaultPlayerSpeed);
		setCameraSpeed(defaultCameraSpeed);
	}

	// Check item effects before checking player movement.
	void FixedUpdate() {
		ItemManager.checkItems();
		playerMovement();
	}

	/*
	 * Updates the player movement when a key is pressed,
	 * or when the mouse axis changes.
	 */
	private void playerMovement() {
		
		// Updates "Forward" key movement
		if (Input.GetKey(KeyCode.W)) {
			this.transform.localPosition += transform.forward * playerSpeed * Time.deltaTime;
		}
		// Updates "Backward" key movement
		if (Input.GetKey(KeyCode.S)) {
			this.transform.localPosition -= transform.forward * playerSpeed * Time.deltaTime;
		}
		// Updates "Right" key movement
		if (Input.GetKey (KeyCode.D)) {
			this.transform.localPosition += transform.right * playerSpeed * Time.deltaTime;
		}
		// Updates "Left" key movement
		if (Input.GetKey(KeyCode.A)) {
			this.transform.localPosition -= transform.right * playerSpeed * Time.deltaTime;
		}

		// Updates "Yaw and Pitch" Movement.
		if (Input.mousePresent) {

			// Updates "Yaw" Movement (Left & Right).
			yaw += Input.GetAxis("Mouse X") * cameraSpeed * Time.deltaTime; 
			//rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);

			// Updates "Pitch" Movement (Up & Down).
			//pitch += Input.GetAxis ("Mouse Y") * cameraSpeed * Time.deltaTime;
			//rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			/*
			if (pitch > 10) {
				pitch = 10;
			} else if (pitch < -10) {
				pitch = -10;
			}*/

			// Updates each change.
			this.transform.eulerAngles = new Vector3(-0, yaw, 0);
		}
	}
}