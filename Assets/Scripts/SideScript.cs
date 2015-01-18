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

				int posx = 50, posy = 125, newline = 140, b_width = 130, b_height = 60;
				if (!sideChosen) {
						if (GUI.Button (new Rect (posx, posy, b_width, b_height), SideButtons [0])) {
								sideChosen = true;
								game_script.SetNextSide (lastNumbers [0]);
						}
			

						posx += newline;
						if (GUI.Button (new Rect (posx, posy, b_width, b_height), SideButtons [1])) {
								sideChosen = true;
								game_script.SetNextSide (lastNumbers [1]);
						}

						posx += newline;
						if (GUI.Button (new Rect (posx, posy, b_width, b_height), SideButtons [2])) {
								sideChosen = true;
								game_script.SetNextSide (lastNumbers [2]);
						}


				} else {
						if (GUI.Button (new Rect (180, 130, 200, 70), nextlevel_b)) {
								Application.LoadLevel (game_script.getLevel ());
						}
				}
		}
}