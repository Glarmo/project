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
	public int scrollScalingSpeed; 

	private float xLeftScaling;
	private float xRightScaling;
	private float yBottomScaling;
	private float yTopScaling;
	
	// Update is called once per frame
	void Update () 
	{
		zoomCamera ();

		float mousePosX = Input.mousePosition.x; 
		float mousePosY = Input.mousePosition.y; 

		xLeftScaling = -scrollSpeed / mousePosX * scrollScalingSpeed;
		xRightScaling = scrollSpeed / (Screen.width - mousePosX) * scrollScalingSpeed;
		yBottomScaling = scrollSpeed / mousePosY * scrollScalingSpeed;
		yTopScaling = -scrollSpeed / (Screen.height - mousePosY) * scrollScalingSpeed;

		if (xLeftScaling > 70) 
		{
			xLeftScaling = 70;
		}

		if (xRightScaling > 70)
		{
			xRightScaling = 70;
		}

		if (yBottomScaling > 70)
		{
			yBottomScaling = 70;
		}

		if (yTopScaling > 70)
		{
			yTopScaling = 70;
		}
		
		if (mousePosX < scrollDistance) 
		{ 
			if (xLeftScaling < 0)
			{
				xLeftScaling = -70;
			}
			transform.Translate(Vector3.right * xLeftScaling * Time.deltaTime); 
		} 
		
		if (mousePosX >= Screen.width - scrollDistance) 
		{ 
			if (xRightScaling < 0)
			{
				xRightScaling = 70;
			}
			transform.Translate(Vector3.right * xRightScaling * Time.deltaTime); 
		}
		
		if (mousePosY < scrollDistance) 
		{ 
			if (yBottomScaling < 0)
			{
				yBottomScaling = 70;
			}
			transform.Translate(transform.forward * yBottomScaling * Time.deltaTime); 
		} 
		
		if (mousePosY >= Screen.height - scrollDistance) 
		{ 
			if (yTopScaling < 0)
			{
				yTopScaling = -70;
			}
			transform.Translate(transform.forward * yTopScaling * Time.deltaTime); 
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
