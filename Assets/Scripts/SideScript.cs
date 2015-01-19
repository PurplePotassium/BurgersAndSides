using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SideScript : MonoBehaviour {
	GameObject Manager;
	MainScript game_script;

	float tamx = 0f;
	float tamy = 0f;
	float posx = 0f ;
	float  posy = 0f;
	public Texture2D bg_img;
	public Texture2D nextlevel_b;
	public Texture2D[] SidesToChoose;
	Texture2D[] SideButtons;
	List<int> lastNumbers = new List<int>();
	bool sideChosen = false;

	void Start () {
		Manager = GameObject.Find ("GameManager");
		game_script = Manager.GetComponent<MainScript> ();
		SideButtons = new Texture2D[3];
		setRandomButtons ();
	}
	
	void setRandomButtons () {
		int randomNumber;
		for (int i=0; i<3; i++) {
			randomNumber = Random.Range(0,5);
			while(lastNumbers.Contains(randomNumber)){
				randomNumber = Random.Range(0,5);
			}
			lastNumbers.Add(randomNumber);
			SideButtons[i] = SidesToChoose[randomNumber];
				}
		
	}

	void OnGUI(){
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bg_img);

				int posx = (Screen.width/4), posy = (Screen.height/2), newline = 140, b_width = 130, b_height = 60;
				if (!sideChosen) {
						GUI.Label (new Rect ((posx+b_width/4), posy-20, b_width, b_height), 
			            game_script.getSideName(lastNumbers [0]));
						if (GUI.Button (new Rect (posx, posy, b_width, b_height), SideButtons [0])) {
								sideChosen = true;
								game_script.SetNextSide (lastNumbers [0]);
						}
			

						posx += newline;
						GUI.Label (new Rect ((posx+b_width/4), posy-20, b_width, b_height), 
			            game_script.getSideName(lastNumbers [1]));
						if (GUI.Button (new Rect (posx, posy, b_width, b_height), SideButtons [1])) {
								sideChosen = true;
								game_script.SetNextSide (lastNumbers [1]);
						}

						posx += newline;
						GUI.Label (new Rect ((posx+b_width/4), posy-20, b_width, b_height), 
			            game_script.getSideName(lastNumbers [2]));
						if (GUI.Button (new Rect (posx, posy, b_width, b_height), SideButtons [2])) {
								sideChosen = true;
								game_script.SetNextSide (lastNumbers [2]);
						}


				} else {
						if (GUI.Button (new Rect (posx, posy, 200, 70), nextlevel_b)) {
								Application.LoadLevel (game_script.getLevel ());
						}
				}
		}
}