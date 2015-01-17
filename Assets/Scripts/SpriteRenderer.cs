using UnityEngine;
using System.Collections;

public class SpriteRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.color = new Color (228.0f, 114.0f, 128.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		//renderer.material.color = new Color (renderer.material.color.r - (228.0f - 153.0f) / 255.0f, renderer.material.color.g - (114.0f - 73.0f) / 255.0f, renderer.material.color.b - 128 / 255.0f, 0.0f);
	}
}
