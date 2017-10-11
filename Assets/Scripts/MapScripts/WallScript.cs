using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {
	
	public Texture texture;


	// Use this for initialization
	void Start () {
		
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		renderer.material.shader = Shader.Find("Unlit/WallShader");
		renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
