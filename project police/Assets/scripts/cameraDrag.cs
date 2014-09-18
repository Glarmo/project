using UnityEngine;
using System.Collections;

public class cameraDrag : MonoBehaviour 
{
    
    public float dragSpeed;
    private Vector3 dragOrigin;

	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
              Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
              Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed);
            
              transform.Translate(-move, Space.World);
			  transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10,10),Mathf.Clamp(transform.position.y, -10,10), -10);
        }
	
	}
}
