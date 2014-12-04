using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
	public Transform destination;

	private bool complete = false;
	private NavMeshAgent navComp;
	
	void Start () 
	{
		navComp = GetComponent <NavMeshAgent>();
	}

	void Update () 
	{
		if (destination == null)
		{
			destination = GameObject.FindGameObjectWithTag("ReturnPoint").GetComponent<Transform>();
			complete = true;
		}

		navComp.SetDestination(destination.position);		//Sets destination 
	}


	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "crime")
		{
			Destroy(other.gameObject);
			randomInstance.crimeCount--;	
			destination = GameObject.FindGameObjectWithTag("ReturnPoint").GetComponent<Transform>();
			complete = true;			//Tells the GM that it has completed the task
			randomInstance.money+=100;
			print (randomInstance.money);
		}

		if (other.tag == "ReturnPoint" && complete == true) 
		{
			randomInstance.unitCount++;
			Destroy(gameObject);
		}
	}
}
