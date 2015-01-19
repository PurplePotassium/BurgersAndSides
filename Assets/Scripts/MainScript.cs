using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	public string[] SideNames = new string[6]{"Eggs","Bacon","Pancakes","Donuts","Onions","Fries"};
	public GameObject[] Sides_obj;
	public int current_index = -1;
	int nextLevel = 0;

	void Start () {
		DontDestroyOnLoad (this.gameObject);
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

	public string getSideName(int index){
		return SideNames[index];
	}

}
