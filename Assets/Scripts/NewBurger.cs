using UnityEngine;
using System.Collections;

public class NewBurger : MonoBehaviour {
	enum CurrentSide {One,Two};
	public GameObject other;
	public float color_change = 1.5f;
	float current_timer = 0f, max_cook = 1.7f;
	SpriteRenderer[] SpriteColor;
	CurrentSide state;
	Vector2 CookLevel;
	float cook_level = 0f;
	bool isBurned = false;
	GameObject Manager;
	public int BurgerPenalty = 7;
	public Vector3 FirstColor;
	public Vector3 SecondColor;

	void Start () {
		Manager = GameObject.Find ("Manager");
		state = CurrentSide.One;
		SpriteColor = new SpriteRenderer[2];
		CookLevel.y = 0f;
		CookLevel.x = 0f;
		GetComponent<SpriteRenderer> ().color = Color.red;
		other.GetComponent<SpriteRenderer> ().color = Color.red;
		SpriteColor [0] = GetComponent<SpriteRenderer> ();
		SpriteColor [1] = other.GetComponent<SpriteRenderer> ();
		current_timer = color_change;
	}


	void Flip(){
		//Debug.Log(this.animation)
		//Invoke ("TurnAnimOFF", 5f);
		//GetComponent<Animator>().enabled = true;

		//GetComponent<Animator> ().SetBool ("Flip", true);
		//this.animation.Play();

		if (state == CurrentSide.One) {
			state = CurrentSide.Two;
			CookLevel.x = cook_level;
			cook_level = CookLevel.y;
		} else {
			state = CurrentSide.One;
			CookLevel.y = cook_level;
			cook_level = CookLevel.x;
		}
		GetComponent<SpriteRenderer> ().color = other.GetComponent<SpriteRenderer> ().color;
		other.GetComponent<SpriteRenderer> ().color = GetComponent<SpriteRenderer> ().color;

	}
	
	void ChangeColor (){
		other.GetComponent<SpriteRenderer> ().color = Color.Lerp(new Color (FirstColor.x, FirstColor.y, FirstColor.z, 1.0f),
		                                                         new Color (SecondColor.x, SecondColor.y, SecondColor.z, 1.0f),cook_level);
		//other.GetComponent<SpriteRenderer> ().color = 	Color.Lerp(new Color (238.0f / 255.0f, 114.0f / 255.0f, 128.0f / 255.0f, 1.0f),
		//           new Color (153.0f / 255.0f, 73.0f / 255.0f, 0.0f, 1.0f),cook_level);
		
	}
	
	void Burned(){
		Manager.GetComponent<BurgerBar> ().curHealth -= BurgerPenalty;
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
		if (current_timer <= 0 && !isBurned) {

			ChangeColor ();
			cook_level += 0.15f;							
			current_timer = color_change;
			if ( cook_level >= max_cook) Burned();
		}
		
	}
	
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (1) && !isBurned)
			DeliverBurguer ();
	}
	
	void OnMouseDown(){		
		if(!isBurned)
			Flip ();
	}
}
