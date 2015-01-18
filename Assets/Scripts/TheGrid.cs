using UnityEngine;
using System.Collections;

public class TheGrid : MonoBehaviour
{
    public GameObject burger;

    public GameObject[,] grill;
    public bool[,] occupied;
    public Vector3[,] location;

    const int WIDTH = 18;
    const int HEIGHT = 9;

    // Use this for initialization
    void Start()
    {
        grill = new GameObject[WIDTH, HEIGHT];
        occupied = new bool[WIDTH, HEIGHT];
        location = new Vector3[WIDTH, HEIGHT];
        for (int x = 0; x < WIDTH; ++x)
            for (int y = 0; y < HEIGHT; ++y)
                location[x, y] = new Vector3(Screen.width / (x+1), Screen.height / (y+1), 0);
        StartCoroutine(BurgerSpawner());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator BurgerSpawner()
    {
        AddFood(burger);
        yield return new WaitForSeconds(0.5f);
    }

    //removes food from given x,y coordinate in grid
    public GameObject RemoveFood(int x, int y)
    {
        GameObject removed;
        removed = grill[x, y];
        grill[x, y] = null;
        return removed;
    }

    //removes all instances of food from the grid
    public void RemoveFood(GameObject food)
    {
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                if (grill[x, y] == food)
                    grill[x, y] = null;
            }
        }
    }

    //Adds food to specific location in grid
    public void AddFood(GameObject food, int x, int y)
    {
        if (!occupied[x, y])
        {
            grill[x, y] = food;
            Instantiate(food, location[x, y],food.transform.rotation);
            occupied[x, y] = true;
        }
        else
            Debug.Log(x + " " + y + " is occupied");
        occupied[x, y] = true;
    }

    //Adds to a random location in grid.
    public void AddFood(GameObject food)
    {
        int x = Random.Range(0, WIDTH);
        int y = Random.Range(0, HEIGHT);
        if (!occupied[x, y])
        {
            grill[x, y] = food;
            Instantiate(food, location[x, y], food.transform.rotation);
            occupied[x, y] = true;
        }
        else
            AddFood(food);
    }
}
