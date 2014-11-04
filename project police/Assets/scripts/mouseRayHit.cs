using UnityEngine;
using System.Collections;

public class mouseRayHit : MonoBehaviour 
{
	private Ray ray;
	private RaycastHit hit;
	void Start () 
    {
	
	}
	

	void Update () 
    {
        if (Input.GetMouseButtonDown (0)) 
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.name == "Map Detect")
				{
					print ("hit map");
					Vector2 mapCoords = hit.textureCoord;
					print (mapCoords);
				}
			}
			
		}
	}
}
