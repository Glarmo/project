using UnityEngine;
using System.Collections;

public class cameraDragV4 : MonoBehaviour 
{

	public int zoomMaxSize;
	public int zoomMinSize;
	public int minX;
	public int maxX;
	public int minZ;
	public int maxZ;
	public int scrollDistance = 5; 
	public int scrollSpeed = 70;



	
	// Update is called once per frame
	void Update () 
	{
		zoomCamera ();
		float mousePosX = Input.mousePosition.x; 
		float mousePosY = Input.mousePosition.y; 
		
		if (mousePosX < scrollDistance) 
		{ 
			transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime); 
		} 
		
		if (mousePosX >= Screen.width - scrollDistance) 
		{ 
			transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime); 
		}
		
		if (mousePosY < scrollDistance) 
		{ 
			transform.Translate(transform.forward * scrollSpeed * Time.deltaTime); 
		} 
		
		if (mousePosY >= Screen.height - scrollDistance) 
		{ 
			transform.Translate(transform.forward * -scrollSpeed * Time.deltaTime); 
		}

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), 15, Mathf.Clamp(transform.position.z, minZ, maxZ));
	}

	void zoomCamera()
	{
		// zoom out
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize >= zoomMinSize)
		{
			Camera.main.orthographicSize--;
			//dragSpeed = dragSpeed + 0.5f;
		}
		// zoom in
		if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize <= zoomMaxSize)
		{
			Camera.main.orthographicSize++;
			//dragSpeed = dragSpeed - 0.5f;
		}
	}
}
