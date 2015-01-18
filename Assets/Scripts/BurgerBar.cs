using UnityEngine;
using System.Collections;

public class BurgerBar : MonoBehaviour {
	public float maxHealth = 100f;
	public float curHealth = 100f;
	private float healthBarLength;
	public Texture2D bgHP; 	
	public Texture2D fgHP;
	float playerHP = 1.0f;

	void OnGUI()
	{
		Draw_Bar ();
	}

	void Draw_Bar(){
				playerHP = (curHealth / maxHealth);
	
				GUI.BeginGroup (new Rect (0, 0, 180, 33));			
	
				GUI.Box (new Rect (-10, 0, 180, 33), bgHP);			
	
				GUI.BeginGroup (new Rect (-10, 0, playerHP * 180, 33));			
	
				GUI.Box (new Rect (0, 0, 180, 33), fgHP);
	
	
				GUI.EndGroup ();
				GUI.EndGroup ();

				GUI.contentColor = Color.black;
				GUI.Label(new Rect(50,7, 70, 20), curHealth + "/" + maxHealth);
		}

}
