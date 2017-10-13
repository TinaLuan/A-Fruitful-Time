using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	// GameObject to follow (Cube player in this case)
	public GameObject target = null;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		// Update the camera's position according to the target's position
		this.transform.position = target.transform.position;
		this.transform.position += new Vector3(2f, 1.1f, 0);
	}
}
