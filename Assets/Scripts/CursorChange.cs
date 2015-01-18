using UnityEngine;
using System.Collections;

public class CursorChange : MonoBehaviour {
	public Texture2D cursor_img;
	CursorMode cursorMode = CursorMode.ForceSoftware;
	Vector2 hotSpot = Vector2.zero;
	
	
	
	// Use this for initialization
	void Start () {
		hotSpot.y = 150;
		hotSpot.x = 20;
		Cursor.SetCursor(cursor_img, hotSpot, cursorMode);
	}
}
