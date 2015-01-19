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
    public int BurgerPenalty = 7;
    public Vector3 FirstColor;
    public Vector3 SecondColor;
    public bool isBurger = false;
    public bool conveyorStart = false;
    public bool conveyorEnd = false;
    public bool clicked = false;

    public bool cooking = true;
    Vector3 conveyorSpawnPoint = new Vector3(-2f, 4.2f, -0.44f);

    void Start()
    {
        Manager = GameObject.Find("GUI");
        Spawner = GameObject.Find("Spawner");
        state = CurrentSide.One;
        SpriteColor = new SpriteRenderer[2];
        CookLevel.y = 0f;
        CookLevel.x = 0f;
        if (isBurger)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            other.GetComponent<SpriteRenderer>().color = Color.red;
        }
        SpriteColor[0] = GetComponent<SpriteRenderer>();
        SpriteColor[1] = other.GetComponent<SpriteRenderer>();
        current_timer = color_change;
    }


    void Flip()
    {
        //Debug.Log(this.animation)
        //Invoke ("TurnAnimOFF", 5f);
        //GetComponent<Animator>().enabled = true;

        //GetComponent<Animator> ().SetBool ("Flip", true);
        //this.animation.Play();

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
        GetComponent<SpriteRenderer>().color = other.GetComponent<SpriteRenderer>().color;
        other.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;

    }

    void ChangeColor()
    {
        other.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(FirstColor.x, FirstColor.y, FirstColor.z, 1.0f),
                                                                 new Color(SecondColor.x, SecondColor.y, SecondColor.z, 1.0f), cook_level);
        //other.GetComponent<SpriteRenderer> ().color = 	Color.Lerp(new Color (238.0f / 255.0f, 114.0f / 255.0f, 128.0f / 255.0f, 1.0f),
        //           new Color (153.0f / 255.0f, 73.0f / 255.0f, 0.0f, 1.0f),cook_level);

    }

    void Burned()
    {
        Manager.GetComponent<BurgerBar>().curHealth -= BurgerPenalty;
        isBurned = true;
        other.GetComponent<SpriteRenderer>().color = Color.black;
        Debug.Log("You burned the burger");
        Destroy(this.gameObject, 2f);
    }

    void DeliverBurguer()
    {
        cooking = false;
        conveyorSpawnPoint.x = transform.position.x;
        transform.position = new Vector3(transform.position.x, conveyorSpawnPoint.y, transform.position.z);
        Spawner.GetComponent<Conveyor>().burgerArray.Add(this.gameObject);
        Destroy(this.gameObject, 10f);
        if (state == CurrentSide.One)
            CookLevel.x = cook_level;
        else
            CookLevel.y = cook_level;
        if (!isBurned && CookLevel.x >= 1f && CookLevel.y >= 1f)
            Debug.Log("Perfect!");
        else if (!isBurned)
            Debug.Log("Too raw :(");
    }

    void FixedUpdate()
    {
        if (cooking)
        {
            current_timer -= Time.deltaTime;
            if (current_timer <= 0 && !isBurned && !conveyorStart)
            {

                ChangeColor();
                cook_level += 0.15f;
                current_timer = color_change;
                if (cook_level >= max_cook) Burned();
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !isBurned)
            DeliverBurguer();
    }

    void OnMouseDown()
    {
        if (!isBurned)
            Flip();
        if (conveyorStart)
            clicked = true;
    }
}
