using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {
	
	public Texture texture;
	public Shader shader;

	// Use this for initialization
	void Start () {
		
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		//renderer.material.shader = Shader.Find("Unlit/WallShader");
		renderer.material.shader = shader;
		renderer.material.mainTexture = texture;
	}

	
	// Update is called once per frame
	void Update () {
		
//		Mesh mesh = GetComponent<MeshFilter>().mesh;
//		Vector3[] vertices = mesh.vertices;
//		int i = 0;
//		while (i < vertices.Length) {
//			vertices[i] += Vector3.up * Time.deltaTime;
//			i++;
//		}
//		mesh.vertices = vertices;
//		mesh.RecalculateBounds();

	}
}
