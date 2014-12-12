using UnityEngine;
using System.Collections;

public class clicker : MonoBehaviour 
{
	public GameObject policeCar;
	public Transform target;
	public static int crimeClicked = 0;

	private Ray ray;
	private RaycastHit hit;

	movement script;
	
	void Start ()
	{
		target = transform;									// sets variable to the transform of object
		script = policeCar.GetComponent<movement> ();		//Gives me access to movement script
	}

	void Update ()
	{
		if (guiCreator.doneClicked == 1)
		{
			Vector3 spawnPosition = new Vector3 (0,0,0);
			Quaternion spawnRotation = Quaternion.identity;
			for (int i = 0; i < randomInstance.unitSend; i++)
			{
				Instantiate (policeCar, spawnPosition, spawnRotation);		//spawns car
				randomInstance.unitCount--;
			}
			guiCreator.doneClicked = 0;						//removes gui element
			randomInstance.unitSend = 0;
		}
	}
	

	void OnMouseOver ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			crimeClicked = 1;						//change destination variable in movement script to target
			script.destination = target;
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "building")
		{
			Destroy(gameObject);					//prevents spawning in buildings
			randomInstance.crimeCount--;
		}
	}
}
