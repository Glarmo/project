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
		target = transform;									// sets variable to the transform of object
		script = policeCar.GetComponent<movement> ();		//Gives me access to movement script
	}
	
	

	void OnMouseOver ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			script.destination = target;					//change destination variable in movement script to target
			Vector3 spawnPosition = new Vector3 (0,0,0);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (policeCar, spawnPosition, spawnRotation);
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "building")
		{
			Destroy(gameObject);
			randomInstance.count--;
		}
	}
}
