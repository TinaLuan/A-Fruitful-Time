using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {


	//0 = initial state, 1 = active state, 2 = inactive state
	public int particleMode = 0;
	private float time = 0;
	public int lifetime = 20;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += 0.1;
		if (time >= lifetime) {
			particleMode = 2;
		} else if (time < lifetime && particleMode == 1) {
			
		} else {
			particleMode = (Random.value * 10 - 0.1) % 5;
		}
	}
}
