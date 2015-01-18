using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Conveyor : MonoBehaviour
{
    public GameObject burger;
    public float conveyorSpeed = 1.0f;
    Vector3 conveyorSpawnPoint;
    Vector3 conveyorEndPoint;
    float conveyorDistance;
    List<GameObject> burgerArray = new List<GameObject>();

    void Awake()
    {
        conveyorSpawnPoint = new Vector3(-8.54f, 4.2f, -0.44f);
        conveyorEndPoint = new Vector3(11.55f, 4.2f, -0.44f);
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
            burgerArray[i].transform.position = Vector3.Lerp(conveyorSpawnPoint, conveyorEndPoint, (conveyorSpeed * Time.deltaTime) / conveyorDistance);
        //Instantiate(burger);
        //burger.transform.position = Vector3.Lerp(conveyorSpawnPoint, conveyorEndPoint, (conveyorSpeed * Time.deltaTime)/conveyorDistance);
	
	}

    IEnumerator ConveyorBelt()
    {
        for(int i = 0; i<10; ++i)
        {
            burgerArray.Add(Instantiate(burger,conveyorSpawnPoint,burger.transform.rotation) as GameObject);
            //burgerArray[i].transform.position = Vector3.Lerp(conveyorSpawnPoint, conveyorEndPoint, (conveyorSpeed * Time.deltaTime) / conveyorDistance);
            yield return new WaitForSeconds(1f);
        }
    }
}
