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
			print ("I have detected the done");
			script.destination = target;					//change destination variable in movement script to target
			Vector3 spawnPosition = new Vector3 (0,0,0);
			Quaternion spawnRotation = Quaternion.identity;
			for (int i = 0; i < randomInstance.unitSend; i++)
			{
				print ("I am in the loop");
				Instantiate (policeCar, spawnPosition, spawnRotation);
				randomInstance.unitCount--;
			}
			guiCreator.doneClicked = 0;
			randomInstance.unitSend = 0;
			print ("I am out of here");
		}
	}
	

	void OnMouseOver ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			/*script.destination = target;					//change destination variable in movement script to target
			Vector3 spawnPosition = new Vector3 (0,0,0);
			Quaternion spawnRotation = Quaternion.identity;
			if (guiCreator.doneClicked == 1)
			{
				for (int i = 0; i < randomInstance.unitSend; i++)
				{
					Instantiate (policeCar, spawnPosition, spawnRotation);
					randomInstance.unitCount--;
				}
			}*/
			crimeClicked = 1;

		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "building")
		{
			Destroy(gameObject);
			randomInstance.crimeCount--;
		}
	}
}
