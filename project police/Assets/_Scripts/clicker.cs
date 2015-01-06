using UnityEngine;
using System.Collections;

public class clicker : MonoBehaviour 
{
	public GameObject policeCar;
	public Transform target;
	public GameObject garage;
	public static int crimeClicked = 0;
	public static int successChanceGUI;
	
	private int successChance;
	private int timeLeft = 15;

	movement script;
	
	void Start ()
	{
		garage = GameObject.Find ("PoliceReturn");
		successChance = Random.Range (0, 100);				// sets the chance of success for that particular crime
		target = transform;									// sets variable to the transform of object
		script = policeCar.GetComponent<movement> ();		//Gives me access to movement script
		StartCoroutine (crimeTimer ());
	}

	void Update ()
	{
		if (guiCreator.doneClicked == 1)
		{
			Vector3 spawnPosition = garage.transform.position;
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
	
	IEnumerator crimeTimer ()
	{
		yield return new WaitForSeconds (timeLeft);
		Destroy (gameObject);
		randomInstance.crimeCount--;
	}

	void OnMouseOver ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			timeLeft = 15;
			successChanceGUI = successChance;
			randomInstance.unitSend = 0;
			crimeClicked = 1;						
			script.destination = target;		//change destination variable in movement script to target
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
