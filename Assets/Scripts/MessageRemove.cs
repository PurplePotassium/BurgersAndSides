using UnityEngine;
using System.Collections;

public class MessageRemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Color c = renderer.material.color;
		if(c.a < .05f){
			Destroy (this.gameObject);
			return;
		}
		renderer.material.color = new Color(c.r,c.g,c.b,Mathf.Pow (c.a*.999f,1.12f));
	}
}
