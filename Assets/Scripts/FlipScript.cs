using UnityEngine;
using System.Collections;

public class FlipScript : MonoBehaviour {
	public enum CookState {Raw, twenty,eighty,Done,Burned};
	enum CurrentSide {One,Two};
	public float state_timer = 1.7f, color_change = 2.0f;
	float current_timer = 0f, max_cook = 2f;
	CurrentSide state;
	Color[] Colors;
	Vector2 CookLevel;
	float cook_level = 0f;
	bool isBurned = false;

	void Start () {
		Colors = new Color[2];
		state = CurrentSide.One;
		CookLevel.y = 0f;
		CookLevel.x = 0f;
		GetComponent<SpriteRenderer> ().color = Color.red;
		Colors [1] = Color.red;
		current_timer = color_change;
	}

	void Flip(){
		Debug.Log ("X");
		if (state == CurrentSide.One) {
						state = CurrentSide.Two;
						Colors[0] = GetComponent<SpriteRenderer> ().color;
						CookLevel.x = cook_level;
						cook_level = CookLevel.y;
						GetComponent<SpriteRenderer> ().color = Colors[1];
				} else {
						state = CurrentSide.One;
						Colors[1] = GetComponent<SpriteRenderer> ().color;
						CookLevel.y = cook_level;
						cook_level = CookLevel.x;
						GetComponent<SpriteRenderer> ().color = Colors[0];
				}


	}

	void ChangeColor (){
		GetComponent<SpriteRenderer> ().color = Color.Lerp(new Color (228.0f / 255.0f, 114.0f / 255.0f, 128.0f / 255.0f, 1.0f),
		                                                   new Color (153.0f / 255.0f, 73.0f / 255.0f, 0.0f, 1.0f),cook_level);

	}
	 
	void Burned(){
		isBurned = true;
		GetComponent<SpriteRenderer> ().color = Color.black;
		Debug.Log ("You burned the burger");
		//
	}

	void DeliverBurguer(){
		Destroy (this.gameObject);
		if (state == CurrentSide.One) 
			CookLevel.x = cook_level;
		else
			CookLevel.y = cook_level;
		if (!isBurned && CookLevel.x >= 1f && CookLevel.y >= 1f)
						Debug.Log ("Perfect!");
	}
	void FixedUpdate(){
		current_timer -= Time.deltaTime;
		if (current_timer <= 0) {
						ChangeColor ();
						cook_level += 0.15f;
						if ( cook_level >= max_cook) Burned();							
						current_timer = color_change;
				}

	}

	void Update(){
		if (Input.GetMouseButtonDown (1))
						DeliverBurguer ();


	}

	void OnMouseDown(){
		if(!isBurned)
			Flip ();
	}
}
