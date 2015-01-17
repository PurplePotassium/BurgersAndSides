﻿using UnityEngine;
using System.Collections;

public class NewBurger : MonoBehaviour {
	enum CurrentSide {One,Two};
	public GameObject other;
	public float state_timer = 1.7f, color_change = 1.3f;
	float current_timer = 0f, max_cook = 1.7f;
	SpriteRenderer[] SpriteColor;
	CurrentSide state;
	Color[] Colors;
	Vector2 CookLevel;
	float cook_level = 0f;
	bool isBurned = false;
	
	void Start () {
		Colors = new Color[2];
		state = CurrentSide.One;
		SpriteColor = new SpriteRenderer[2];
		CookLevel.y = 0f;
		CookLevel.x = 0f;
		SpriteColor [0] = GetComponent<SpriteRenderer> ();
		SpriteColor [1] = other.GetComponent<SpriteRenderer> ();
		GetComponent<SpriteRenderer> ().color = Color.red;
		other.GetComponent<SpriteRenderer> ().color = Color.red;
		Colors [1] = Color.red;
		current_timer = color_change;
	}
	
	void Flip(){
		if (state == CurrentSide.One) {
			state = CurrentSide.Two;
			SpriteColor [0].color = other.GetComponent<SpriteRenderer> ().color;
			SpriteColor [1].color = GetComponent<SpriteRenderer> ().color;
			CookLevel.x = cook_level;
			cook_level = CookLevel.y;
			other.GetComponent<SpriteRenderer> ().color = SpriteColor [0].color;
			GetComponent<SpriteRenderer> ().color = SpriteColor [1].color;
		} else {
			state = CurrentSide.One;
			SpriteColor [1].color = other.GetComponent<SpriteRenderer> ().color;
			SpriteColor [0].color = GetComponent<SpriteRenderer> ().color;
			CookLevel.y = cook_level;
			cook_level = CookLevel.x;
			other.GetComponent<SpriteRenderer> ().color = SpriteColor [1].color;
			GetComponent<SpriteRenderer> ().color = SpriteColor [0].color;
		}
		
		
	}
	
	void ChangeColor (){
		other.GetComponent<SpriteRenderer> ().color = Color.Lerp(new Color (238.0f / 255.0f, 114.0f / 255.0f, 128.0f / 255.0f, 1.0f),
		                                                   new Color (153.0f / 255.0f, 73.0f / 255.0f, 0.0f, 1.0f),cook_level);
		
	}
	
	void Burned(){
		isBurned = true;
		other.GetComponent<SpriteRenderer> ().color = Color.black;
		Debug.Log ("You burned the burger");
		Destroy (this.gameObject, 2f);
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
	
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (1))
			DeliverBurguer ();
	}
	
	void OnMouseDown(){		
		if(!isBurned)
			Flip ();
	}
}
