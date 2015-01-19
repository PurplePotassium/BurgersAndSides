using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public void buttonClick(){
		Debug.Log ("Button Clicked");
		//actually number the levels when the time comes then i should work
		Application.LoadLevel(0);
	}

	public void startLevel(){
		//same as the first one
		Application.LoadLevel("maingame3");
	}
	public void exitGame(){
		Application.Quit();
	}
	//uncomment when game over screen is shown. and the return to menu button is made
	//public void loadTitleScreen(){
		
		//Application.LoadLevel(2);
	//}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}