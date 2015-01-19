using UnityEngine;
using System.Collections;

public class CursorChange : MonoBehaviour {
	public Texture2D cursor_img;
	CursorMode cursorMode = CursorMode.ForceSoftware;
	Vector2 hotSpot = Vector2.zero;
	
	
	
	// Use this for initialization
	void Start () {
		hotSpot.y = 10;
		hotSpot.x = 10;
		Cursor.SetCursor(cursor_img, hotSpot, cursorMode);
	}
}
