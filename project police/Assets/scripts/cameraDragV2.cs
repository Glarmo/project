using UnityEngine;
using System.Collections;

public class cameraDragV2 : MonoBehaviour {

	public float dragSpeed;
	public int minX;
	public int maxX;
	public int minZ;
	public int maxZ;
	
	public int bottomMargin = 80; 

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
		
		if(dragOrigin.y <= bottomMargin) return;
		
		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
		
		/*if(move.x > 0)
		{
			if(!isWithinRightBorder())
				move.x =0;
		}
		else
		{
			if(!isWithinLeftBorder())
				move.x=0;
		}
		
		if(move.z > 0)
		{
			if(!isWithinTopBorder())
				move.z=0;
		}
		else
		{
			if(!isWithinBottomBorder())
				move.z=0;
		}*/
		
		
		transform.Translate(move, Space.World);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), 15, Mathf.Clamp(transform.position.z, minZ, maxZ));
	}
	
	void zoomCamera()
	{
		/*if(!isWithinBorders())
		{
			return;
		}*/

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
	
/*	bool isWithinBorders()
	{
		return ( isWithinLeftBorder() && isWithinBottomBorder() && isWithinRightBorder() && isWithinTopBorder() );
	}
	
	bool isWithinLeftBorder()
	{
		Vector3 currentTopLeftGlobal = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
		if(currentTopLeftGlobal.x > minX)
			return true;
		else
			return false;
		
	}
	
	bool isWithinRightBorder()
	{
		Vector3 currentBottomRightGlobal = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0));
		if(currentBottomRightGlobal.x < maxX)
			return true;
		else
			return false;
	}
	
	bool isWithinTopBorder()
	{
		Vector3 currentTopLeftGlobal = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));
		if(currentTopLeftGlobal.z < maxZ)
			return true;
		else
			return false;
	}
	
	bool isWithinBottomBorder()
	{
		Vector3 currentBottomRightGlobal = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0));
		if(currentBottomRightGlobal.z > minZ)
			return true;
		else
			return false;
	}*/
}
