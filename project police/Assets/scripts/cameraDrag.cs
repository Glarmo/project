using UnityEngine;
using System.Collections;

public class cameraDrag : MonoBehaviour 
{
    public float dragSpeed;
    private float OriginalDragSpeed = 1;
    private Vector3 dragOrigin;
    private float cameraSizeMax = 12;
    private float cameraSizeMin = 5;
    private float size = Camera.main.orthographicSize/7;

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
			  transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10/size,10/size),Mathf.Clamp(transform.position.y, -10/size,10/size), -10);
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize >= cameraSizeMin)
        {
            Camera.main.orthographicSize--;
            dragSpeed = OriginalDragSpeed * Camera.main.orthographicSize/6;
            size = Camera.main.orthographicSize/5;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize <= cameraSizeMax)
        {
            Camera.main.orthographicSize++;
            dragSpeed = OriginalDragSpeed * Camera.main.orthographicSize/4;
            size = Camera.main.orthographicSize/3;
        }
    }
}
