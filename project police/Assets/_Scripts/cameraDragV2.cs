using UnityEngine;
using System.Collections;

public class cameraDragV2 : MonoBehaviour 
{

	public float dragSpeed;
	public int minX;
	public int maxX;
	public int minZ;
	public int maxZ;
	
	public int topMargin; 

	public int zoomMaxSize;
	public int zoomMinSize;

	private Vector3 dragOrigin;

	void Update () {
		moveCamera();
		zoomCamera();
	}
	
	void moveCamera()
	{
		if (Input.GetMouseButtonDown(0))
		{    
			dragOrigin = Input.mousePosition;
			return;
		}
		
		if (!Input.GetMouseButton(0)) return;
		
		if(dragOrigin.y >= topMargin) return;
		
		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

		transform.Translate(move, Space.World);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), 15, Mathf.Clamp(transform.position.z, minZ, maxZ));
	}
	
	void zoomCamera()
	{
		// zoom out
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize >= zoomMinSize)
		{
			Camera.main.orthographicSize--;
			dragSpeed = dragSpeed + 0.5f;
		}
		// zoom in
		if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize <= zoomMaxSize)
		{
			Camera.main.orthographicSize++;
			dragSpeed = dragSpeed - 0.5f;
		}
	}
}
