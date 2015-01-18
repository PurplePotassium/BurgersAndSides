using UnityEngine;
using System.Collections;

public class CursorChange : MonoBehaviour {
	public Texture2D cursor_img;
	CursorMode cursorMode = CursorMode.ForceSoftware;
	Vector2 hotSpot = Vector2.zero;

	void Start () {
		hotSpot.y = 50;
		hotSpot.x = -130;
		Cursor.SetCursor(cursor_img, hotSpot, cursorMode);
	}
}
