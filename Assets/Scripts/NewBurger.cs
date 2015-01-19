using UnityEngine;
using System.Collections;

public class NewBurger : MonoBehaviour
{
    enum CurrentSide { One, Two };
    public GameObject other;
    public float color_change = 1.5f;
    float current_timer = 0f, max_cook = 1.7f;
    SpriteRenderer[] SpriteColor;
    CurrentSide state;
    Vector2 CookLevel;
    float cook_level = 0f;
    bool isBurned = false;
    GameObject Manager;
    GameObject Spawner;
    public float BurgerPenalty = 7;
    public Color FirstColor;
	public Color SecondColor;
    public bool isBurger = false;
    public bool conveyorStart = false;
    public bool conveyorEnd = false;
    public bool clicked = false;

    public bool cooking = true;
    Vector3 conveyorSpawnPoint = new Vector3(-2f, 4.2f, -0.44f);

    public GameObject perfectMessage;
    public GameObject burnMessage;
    public GameObject rawMessage;

	bool temporarilyswitch;

    void Start()
    {
        Manager = GameObject.Find("GUI");
        Spawner = GameObject.Find("Spawner");
        state = CurrentSide.One;
        SpriteColor = new SpriteRenderer[2];
        CookLevel.y = 0f;
        CookLevel.x = 0f;
		GetComponent<SpriteRenderer>().color = FirstColor;//Color.red;
		other.GetComponent<SpriteRenderer>().color = FirstColor;//Color.red;
        SpriteColor[0] = GetComponent<SpriteRenderer>();
        SpriteColor[1] = other.GetComponent<SpriteRenderer>();
        current_timer = color_change;
    }

    void FlipAnim()
    {
        this.GetComponent<Animator>().SetTrigger("Flip");
        other.GetComponent<Animator>().SetTrigger("Flip");
    }

	bool IsFlipping;
    void Flip()
    {
		IsFlipping = true;
		temporarilyswitch = true;
        if (!conveyorStart)
        {
            GetComponent<SpriteRenderer>().color = other.GetComponent<SpriteRenderer>().color;
            other.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            FlipAnim();
        }

		FinishFlip();/////ASDLFKJ

    }

	void FinishFlip(){
		if (state == CurrentSide.One)
		{
			state = CurrentSide.Two;
			CookLevel.x = cook_level;
			cook_level = CookLevel.y;
		}
		else
		{
			state = CurrentSide.One;
			CookLevel.y = cook_level;
			cook_level = CookLevel.x;
		}
		temporarilyswitch = false;
		IsFlipping = false;
	}

    void ChangeColor(){
		//bool blah = state == CurrentSide.One || temporarilyswitch;
		//GetComponent<SpriteRenderer>().color = Color.Lerp(FirstColor,SecondColor, blah ? CookLevel.x : CookLevel.y);
		//other.GetComponent<SpriteRenderer>().color = Color.Lerp(FirstColor,SecondColor, blah ? CookLevel.y : CookLevel.x);
		bool blah = state == CurrentSide.One || temporarilyswitch;
		GetComponent<SpriteRenderer>().color = Color.Lerp(FirstColor,SecondColor, blah ? CookLevel.y : CookLevel.x);
		other.GetComponent<SpriteRenderer>().color = Color.Lerp(FirstColor,SecondColor, cook_level);
    }

    void Burned()
    {
        Manager.GetComponent<BurgerBar>().curHealth -= BurgerPenalty;
		isBurned = true;
		other.GetComponent<SpriteRenderer>().color = new Color(.05f,.05f,.05f);
		GetComponent<SpriteRenderer>().color = new Color(.05f,.05f,.05f);
		Debug.Log("You burned the burger");
		GameObject temp = Instantiate(burnMessage, new Vector3(0f, 2.08f, -0.88f), perfectMessage.transform.rotation) as GameObject;
		temp.transform.position = new Vector3(transform.position.x,transform.position.y,-5);
        Destroy(this.gameObject, 2f);
    }

    void DeliverBurguer()
    {
		if(!cooking) return;
        cooking = false;
        conveyorSpawnPoint.x = transform.position.x;
        Spawner.GetComponent<Conveyor>().burgerArray.Add(this.gameObject);
        Destroy(this.gameObject, 10f);
        if (state == CurrentSide.One)
            CookLevel.x = cook_level;
        else
            CookLevel.y = cook_level;
		GameObject temp;
		if(isBurned){
			temp = Instantiate(burnMessage, new Vector3(0f, 2.08f, -0.88f), perfectMessage.transform.rotation) as GameObject;
		}else if (CookLevel.x >= 1f && CookLevel.y >= 1f){
            temp = Instantiate(perfectMessage, new Vector3(0f, 2.08f, -0.88f), perfectMessage.transform.rotation) as GameObject;
			StaticScript.GotPerfect();
            Destroy(temp, 2f);
		}else{
			Manager.GetComponent<BurgerBar>().curHealth -= BurgerPenalty/2;
			temp = Instantiate(rawMessage, new Vector3(0f, 2.08f, -0.88f), perfectMessage.transform.rotation) as GameObject;
			Debug.Log("Too raw :(");
		}
		temp.transform.position = transform.position;
		transform.position = new Vector3(transform.position.x, conveyorSpawnPoint.y, transform.position.z);
    }

    void FixedUpdate()
    {
		if(transform.position.x > 15f){
			Manager.GetComponent<BurgerBar>().curHealth -= BurgerPenalty/2;
			Destroy (this.gameObject);
		}
		if(IsFlipping && !this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
			FinishFlip();
        if (cooking)
        {
            current_timer -= Time.deltaTime;
            if (/*current_timer <= 0 && */!isBurned && !conveyorStart)
            {

                ChangeColor();
                cook_level += 0.15f*Time.deltaTime;
                current_timer = color_change;
                if (cook_level >= max_cook) Burned();
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !isBurned){
            DeliverBurguer();
		}
    }

    void OnMouseDown()
    {
		if(!cooking) return;
        if (!isBurned)
            Flip();
        if (conveyorStart)
            clicked = true;
    }
}
