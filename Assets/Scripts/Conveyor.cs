﻿using UnityEngine;
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
        StartCoroutine("ConveyorBelt");
	}
	
	// Update is called once per frame
    void Update()
    {
        for (int i = 0; i < burgerArray.Count; ++i)
        {
            if (burgerArray[i] != null)
            {
                Vector3 curPos = burgerArray[i].transform.position;
                //float percentTraveled = Vector3.Distance(curPos,conveyorSpawnPoint);
                burgerArray[i].transform.position = 
                    Vector3.Lerp(curPos, conveyorEndPoint, conveyorSpeed*Time.deltaTime);
            }
            else
            {
                GetComponent<Spawn>().SpawnOne();
            }
            //if (burgerArray[i].transform.position == conveyorEndPoint)
            //    Destroy(burgerArray[i].gameObject);
        }
        burgerArray = TruncateList(burgerArray);
	}

    List<GameObject> TruncateList(List<GameObject> list1)
    {
        List<GameObject> list2 = new List<GameObject>();
        for (int i = 0; i < list1.Count; ++i)
        {
            if (list1[i] != null)
                list2.Add(burgerArray[i]);
        }
        return list2;
    }

    public void StopConveyor()
    {
        StopCoroutine("ConveyorBelt");
    }

    IEnumerator ConveyorBelt()
    {
        while(true)
        {
            GameObject temp = Instantiate(burger,conveyorSpawnPoint,burger.transform.rotation) as GameObject;
            temp.GetComponent<NewBurger>().conveyor = true;
            burgerArray.Add(temp);
            yield return new WaitForSeconds(3f);
        }
    }
}
