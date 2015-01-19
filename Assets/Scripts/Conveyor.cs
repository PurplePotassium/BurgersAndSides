using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Conveyor : MonoBehaviour
{
	List<Vector3> spawnPoints = new List<Vector3>();
	int spawnPoint = 0;
	
	GameObject manager;
	
	public GameObject lvlManager;
	float sideOrBurgerProbability;
	
	public GameObject burger;
	public float conveyorSpeed = 1.0f;
	Vector3 conveyorSpawnPoint;
	Vector3 conveyorEndPoint;
	float conveyorDistance;
	public List<GameObject> burgerArray = new List<GameObject>();
	
	void Awake()
	{
		Debug.Log ("ASDF");
		manager = GameObject.Find("GUI");
		conveyorSpawnPoint = new Vector3(-18f, 4.2f, -0.44f);
		conveyorEndPoint = new Vector3(16f, 4.2f, -0.44f);
		conveyorDistance = Vector3.Distance(conveyorSpawnPoint, conveyorEndPoint);
	}
	
	// Use this for initialization
	void Start()
	{
		addSpawns();
		StartCoroutine("ConveyorBelt");
	}
	
	// Update is called once per frame
	void Update()
	{
		burgerArray = TruncateList(burgerArray);
		for (int i = 0; i < burgerArray.Count; ++i)
		{
			if (burgerArray[i].GetComponent<NewBurger>().clicked == false)
			{
				Vector3 curPos = burgerArray[i].transform.position;
				float currPos = curPos.x;
				//float percentTraveled = Vector3.Distance(curPos,conveyorSpawnPoint);
				burgerArray[i].transform.position +=
					new Vector3((conveyorEndPoint.x - conveyorSpawnPoint.x) * conveyorSpeed * Time.deltaTime, 0f, 0f);
			}
			else
			{
				SpawnOne(burgerArray[i]);
				Destroy(burgerArray[i]);
				//GetComponent<Spawn>().SpawnOne();
			}
			//if (burgerArray[i].transform.position == conveyorEndPoint)
			//    Destroy(burgerArray[i].gameObject);
		}
	}
	
	void addSpawns()
	{
		spawnPoints.Add(new Vector3(-6.37f, 0.91f, -0.44f));
		spawnPoints.Add(new Vector3(-2.8f, -0.21f, -0.44f));
		spawnPoints.Add(new Vector3(-6.93f, -1.89f, -0.44f));
		spawnPoints.Add(new Vector3(0.56f, -1.89f, -0.44f));
		spawnPoints.Add(new Vector3(0.84f, 1.12f, -0.44f));
		spawnPoints.Add(new Vector3(3.99f, 0.49f, -0.44f));
		spawnPoints.Add(new Vector3(7f, -1.68f, -0.44f));
	}
	
	public void SpawnOne(GameObject food)
	{
		if (spawnPoint >= spawnPoints.Count)
			spawnPoint = 0;
		GameObject temp = Instantiate(food, spawnPoints[spawnPoint++], food.transform.rotation) as GameObject;
		temp.GetComponent<NewBurger>().conveyorStart = false;
		temp.GetComponent<NewBurger>().clicked = false;
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
		while (true)
		{
			GameObject temp = null;
			sideOrBurgerProbability = Random.value;
			Debug.Log(sideOrBurgerProbability);
			if (sideOrBurgerProbability > 0.5f)
				temp = lvlManager.GetComponent<MainScript>().getSide();
			temp = temp ?? burger;
			temp = Instantiate(temp,conveyorSpawnPoint, burger.transform.rotation) as GameObject;
			temp.GetComponent<NewBurger>().conveyorStart = true;
			burgerArray.Add(temp);
			yield return new WaitForSeconds(3f-.25f*StaticScript.Level);
		}
	}
}
