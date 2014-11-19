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
		navComp.SetDestination(destination.position);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "crime")
		{
			Destroy(other.gameObject);
			randomInstance.count--;
			destination = GameObject.FindGameObjectWithTag("ReturnPoint").GetComponent<Transform>();
			complete = true;
		}

		if (other.tag == "ReturnPoint" && complete == true) 
		{
			Destroy(gameObject);
		}
	}
}
