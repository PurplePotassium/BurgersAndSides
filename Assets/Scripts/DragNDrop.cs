using UnityEngine;
using System.Collections;

public class DragNDrop : MonoBehaviour {
    float zInit;
    Vector3 newPos;

	// Use this for initialization
	void Start () {
        zInit = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDrag()
    {
        newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = zInit;
        transform.position = newPos;
    }


}
