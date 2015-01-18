using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
    List<Vector3> spawnPoints = new List<Vector3>();
    bool[] spawned = new bool[7];
    HashSet<int> indexTaken = new HashSet<int>();
    public GameObject burger;

    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
        spawnPoints.Add(new Vector3(-6.37f, 0.91f, -0.44f));
        spawnPoints.Add(new Vector3(-2.8f, -0.21f, -0.44f));
        spawnPoints.Add(new Vector3(-6.93f, -1.89f, -0.44f));
        spawnPoints.Add(new Vector3(0.56f, -1.89f, -0.44f));
        spawnPoints.Add(new Vector3(0.84f, 1.12f, -0.44f));
        spawnPoints.Add(new Vector3(3.99f, 0.49f, -0.44f));
        spawnPoints.Add(new Vector3(7f, -1.68f, -0.44f));

        //StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator Spawner()
    {
        while (true)
        {
            int ran = Random.Range(0, 7);
            if(!indexTaken.Contains(ran))
                Instantiate(burger, spawnPoints[ran], burger.transform.rotation);
            indexTaken.Add(ran);
            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnOne()
    {
        int ran = Random.Range(0, 7);
        if (!indexTaken.Contains(ran))
            Instantiate(burger, spawnPoints[ran], burger.transform.rotation);
        indexTaken.Add(ran);
    }
}
