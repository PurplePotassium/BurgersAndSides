using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	string[] SideNames;
	public GameObject[] Sides_obj;
	public int current_index = -1;
	int nextLevel = 0;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		SideNames = new string[6]{"Eggs","Bacon","Pancakes","Donuts","Onions","Fries"};
	}

	public void SetNextSide(int index){
		current_index = index;
		}

	public GameObject getSide(){
		return Sides_obj[current_index];
		}
	public int getLevel(){
				return nextLevel;
		}
	// Update is called once per frame
	void Update () {
	
	}
}
