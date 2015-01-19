using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public Texture2D background;
	public Texture2D b_play;
	public Texture2D b_quit;
	GameObject Manager;
	Vector2 position;
	// Use this for initialization
	void Start () {
		Manager = GameObject.Find ("GameManager");
		position.x = Screen.width - (Screen.width / 4);
		position.y = (Screen.width / 4) ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);
		if (GUI.Button (new Rect (position.x,position.y,b_play.width, b_play.height), b_play, new GUIStyle())) {
			Application.LoadLevel(Manager.GetComponent<MainScript>().getLevel());

		}
		if (GUI.Button (new Rect (position.x+150,position.y,b_quit.width, b_quit.height), b_quit,new GUIStyle())) {
			Application.Quit();
		}
		}
}
