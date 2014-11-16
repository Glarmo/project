using UnityEngine;
using System.Collections;

public class clicker : MonoBehaviour 
{
	public GameObject policeCar;
	public Transform target;

	private Ray ray;
	private RaycastHit hit;

	movement script;
	
	void Start ()
	{
		target = transform;		// sets target targets transform
		script = policeCar.GetComponent<movement> ();		//Gives me access to movement script
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.name == "target(Clone)")
				{
					//instantiateAgent();
					//print ("hit crime");
				}
			}
		}
	}
	
	void instantiateAgent()
	{
		Vector3 spawnPosition = new Vector3 (0,0,0);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (policeCar, spawnPosition, spawnRotation);
		script.destination = target;
		script.test = 5;
	}

	void OnMouseOver ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Vector3 spawnPosition = new Vector3 (0,0,0);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (policeCar, spawnPosition, spawnRotation);
			script.destination = target;
		}
	}
}
