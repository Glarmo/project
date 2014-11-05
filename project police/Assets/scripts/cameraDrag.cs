using UnityEngine;
using System.Collections;

public class cameraDrag : MonoBehaviour 
{
    public float dragSpeed; 
    public float mapX;
    public float mapZ;

    private Vector3 dragOrigin;

    private float OriginalDragSpeed = 1;
    private float cameraSizeMax = 12;
    private float cameraSizeMin = 5;

    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

	void Update ()
    {
        
        float verticalExtent = Camera.main.orthographicSize;
        float horizontalExtent = verticalExtent * Screen.width / Screen.height;
        
        minX = horizontalExtent - mapX/2;
        maxX = mapX/2 - horizontalExtent;
        minZ = verticalExtent - mapZ/2;
        maxZ = mapZ/2 - verticalExtent;

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
              Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
              Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed);
            
              transform.Translate(-move, Space.World);
			  transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),Mathf.Clamp(transform.position.z, minZ, maxZ), -10);
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize >= cameraSizeMin)
        {
            Camera.main.orthographicSize--;
            dragSpeed = OriginalDragSpeed * Camera.main.orthographicSize/6;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize <= cameraSizeMax)
        {
            Camera.main.orthographicSize++;
            dragSpeed = OriginalDragSpeed * Camera.main.orthographicSize/4;
        }
    }
}
