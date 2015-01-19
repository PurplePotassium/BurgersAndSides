using UnityEngine;
using System.Collections;

public class BurgerBar : MonoBehaviour {
	public float maxHealth = 100f;
	public float curHealth = 100f;
	private float healthBarLength;
	public Texture2D bgHP; 	
	public Texture2D fgHP;
	public GUIStyle style;
	float playerHP = 1.0f;
	// Use this for initialization
	void Start () 
	{
		style = new GUIStyle();
		style.fontSize = 48;
		style.fontStyle = FontStyle.Bold;
		style.alignment = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(curHealth <= 0)
			Application.LoadLevel("Start Menu");
	}

	void OnGUI()
	{
		Draw_Bar ();
	}

	void Draw_Bar(){
		float SIZEX = Screen.width*.5f;
		float SIZEY = SIZEX/180*33;
		float POSY = Screen.height-SIZEY-5;
				playerHP = (curHealth / maxHealth);
		
		/*GUI.Box (new Rect (0, 0, SIZEX, SIZEY), bgHP);			
		GUI.Box (new Rect (10, 0, SIZEX, SIZEY), fgHP);*/
		GUI.Label(new Rect (0, POSY, SIZEX, SIZEY), bgHP);			
		GUI.Label(new Rect (0, POSY, SIZEX*playerHP, SIZEY), fgHP);
	

				//GUI.contentColor = Color.white;
				GUI.Label(new Rect(0,POSY+7-SIZEY/4, SIZEX, SIZEY), (int)(playerHP*maxHealth) + "/" + (int)(maxHealth),style);
		}

	public void AdjustcurHealth(int adj)
	{
		curHealth += adj;
			if (curHealth < 0)
				curHealth = 0;
			if (curHealth > maxHealth)
				curHealth = maxHealth;
			if (maxHealth < 1)
				maxHealth = 1;
	}

}
