using UnityEngine;
using System.Collections;

public class cameraDragV3 : MonoBehaviour 
{

		public int Boundary = 50; // distance from edge scrolling starts
		public int speed = 5;
	
		private int theScreenWidth;
		private int theScreenHeight;
	
	void Start() 
	{
		theScreenWidth = Screen.width;
		theScreenHeight = Screen.height;
	}
	
	/*void Update() 
	{
		if (Input.mousePosition.x > theScreenWidth - Boundary)
		{
			transform.position.x += speed * Time.deltaTime; // move on +X axis
		}
		
		if (Input.mousePosition.x < 0 + Boundary)
		{
			transform.position.x -= speed * Time.deltaTime; // move on -X axis
		}
		
		if (Input.mousePosition.y > theScreenHeight - Boundary)
		{
			transform.position.z += speed * Time.deltaTime; // move on +Z axis
		}
		
		if (Input.mousePosition.y < 0 + Boundary)
		{
			transform.position.z -= speed * Time.deltaTime; // move on -Z axis
		}
		
	}   
	
	void OnGUI() 
	{
		GUI.Box( Rect( (Screen.width / 2) - 140, 5, 280, 25 ), "Mouse Position = " + Input.mousePosition );
		GUI.Box( Rect( (Screen.width / 2) - 70, Screen.height - 30, 140, 25 ), "Mouse X = " + Input.mousePosition.x );
		GUI.Box( Rect( 5, (Screen.height / 2) - 12, 140, 25 ), "Mouse Y = " + Input.mousePosition.y );
	}*/

}