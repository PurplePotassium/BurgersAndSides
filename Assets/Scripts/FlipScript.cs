using UnityEngine;
using System.Collections;

public class FlipScript : MonoBehaviour {
	public enum CookState {Raw, twenty,eighty,Done,Burned};
	enum CurrentSide {One,Two};
	public float state_timer = 1.7f, color_change = 2.0f;
	float current_timer = 0f, max_cook = 1f;
	CurrentSide state;
	Color[] Colors;
	Vector2 CookLevel;
	float cook_level = 0f;


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
			GetComponent<SpriteRenderer> ().color = Color.Lerp(Color.red,Color.gray,cook_level);

	}

	void ThrowAway(){
		Destroy (this.gameObject);
	}

	void FixedUpdate(){
		current_timer -= Time.deltaTime;
		if (current_timer <= 0) {
						ChangeColor ();
						cook_level += 0.2f;
						if ( cook_level >= max_cook) ThrowAway();							
						current_timer = color_change;
				}

	}

	void OnMouseDown(){
		Flip ();
	}
}
