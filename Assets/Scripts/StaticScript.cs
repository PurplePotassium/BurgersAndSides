using UnityEngine;
using System.Collections;

public class StaticScript : MonoBehaviour {
	public static int Level = 0;

	public static int PerfectsNeeded = 1;

	public static bool[] AvailableSides = new bool[6];//{true,true,true,true,true,true};

	public static void GotPerfect(){
		if(--PerfectsNeeded == 0){
			NextLevel();
		}
	}

	static float ShowLevel = 1;
	static float LevelEndCountdown;

	public static void ActualNextLevel(){
		Application.LoadLevel("maingame3");//Application.loadedLevelName);
	}

	public static void NextLevel(){
		Level++;
		ShowLevel = 1;
		LevelEndCountdown = 1;
	}

	public GUIStyle style;
	void Start(){
		float playerHP = 1.0f;
		style = new GUIStyle();
		style.fontSize = 48;
		style.fontStyle = FontStyle.Bold;
		style.alignment = TextAnchor.MiddleCenter;
		style.richText = true;
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update(){
	}

	void OnGUI(){
		if(LevelEndCountdown > 0){
			Rect pos = new Rect(0,0,800,200);
			if((LevelEndCountdown -= Time.deltaTime/5) <= 0){
				Application.LoadLevel("SideChoosing");
				PerfectsNeeded = Level+1;
				PerfectsNeeded *= 2;
			}
			GUI.Label(pos,"<color=#000000><size=104>LEVEL COMPLETE</size></color>",style);
			GUI.Label(pos,"<color=#8000FF><size=100>LEVEL COMPLETE</size></color>",style);
		}else if(ShowLevel > 0){
			Rect pos = new Rect(0,(int)(-LevelEndCountdown*Screen.height),800,200);
			ShowLevel -= Time.deltaTime/3;
			GUI.Label(pos,"<color=#000000><size=104>LEVEL "+(StaticScript.Level+1)+"</size></color>",style);
			GUI.Label(pos,"<color=#8000FF><size=100>LEVEL "+(StaticScript.Level+1)+"</size></color>",style);
		}
	}
}
