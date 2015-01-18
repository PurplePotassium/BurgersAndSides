using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Conveyor : MonoBehaviour
{
    GameObject manager;

    public GameObject burger;
    public float conveyorSpeed = 1.0f;
    Vector3 conveyorSpawnPoint;
    Vector3 conveyorEndPoint;
    float conveyorDistance;
    List<GameObject> burgerArray = new List<GameObject>();

    void Awake()
    {
        manager = GameObject.Find("GUI");
        conveyorSpawnPoint = new Vector3(-8.54f, 4.2f, -0.44f);
        conveyorEndPoint = new Vector3(14f, 4.2f, -0.44f);
        conveyorDistance = Vector3.Distance(conveyorSpawnPoint, conveyorEndPoint);
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(ConveyorBelt());
	}
	
	// Update is called once per frame
    void Update()
    {
        for (int i = 0; i < burgerArray.Count; ++i)
            if(burgerArray[i]!=null)
            {
                burgerArray[i].transform.position = Vector3.Lerp(burgerArray[i].transform.position, conveyorEndPoint,
                    conveyorSpeed * Time.deltaTime);
            }
            else
            {
                GetComponent<Spawn>().SpawnOne();
            }
	
	}

    IEnumerator ConveyorBelt()
    {
        for(int i = 0; i<10; ++i)
        {
            GameObject temp = Instantiate(burger,conveyorSpawnPoint,burger.transform.rotation) as GameObject;
            temp.GetComponent<NewBurger>().conveyor = true;
            burgerArray.Add(temp);
            yield return new WaitForSeconds(3f);
        }
    }
}
