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
		StaticScript.AvailableSides[index] = true;
		}

	public GameObject getSide(){
		ArrayList available = new ArrayList();
		for(int i = 0; i < Sides_obj.Length; i++)
			if(StaticScript.AvailableSides[i])
				available.Add(i);
		if(available.Count == 0)
			return null;
		return Sides_obj[(int)available[Random.Range(0,available.Count-1)]];
	}
	public int getLevel(){
				return nextLevel;
		}

	public string getSideName(int index){
		return SideNames[index];
	}

}
