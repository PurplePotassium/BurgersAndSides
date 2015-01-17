using UnityEngine;
using System.Collections;

public class SpriteRecolor : MonoBehaviour {

	public float duration;
	private float timeElapsed;

	// Use this for initialization
	void Start () {
		timeElapsed = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeElapsed < duration) {
			timeElapsed += Time.deltaTime;
		}

		renderer.material.color = Color.Lerp (new Color (228.0f / 255.0f, 114.0f / 255.0f, 128.0f / 255.0f, 1.0f),
		                                      new Color (153.0f / 255.0f, 73.0f / 255.0f, 0.0f, 1.0f), 
		                                      timeElapsed / duration);
	}
}
