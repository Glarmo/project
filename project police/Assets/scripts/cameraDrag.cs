using UnityEngine;
using System.Collections;

public class cameraDrag : MonoBehaviour 
{
    
    public float dragSpeed;
    private Vector2 dragOrigin;

	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
              Vector2 pos = Camera.main.ScreenToViewportPoint(Event.mousePosition - dragOrigin);
              Vector2 move = new Vector2(pos.x * dragSpeed, pos.y * dragSpeed);
            
              transform.Translate(move, Space.World);
        }
	
	}
}
