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
				print ("hit something");
				Vector2 location = hit.textureCoord;
				print (location);
				if (hit.transform.name == "MapV2")
				{
					print ("hit map");
					Vector2 mapCoords = hit.textureCoord;
					print (mapCoords);
				}
			}
			
		}
	}
}
