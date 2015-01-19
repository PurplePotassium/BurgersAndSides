using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		this.GetComponent<Animator> ().SetTrigger("Flip");

	}
}
