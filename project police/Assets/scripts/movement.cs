using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
	public Transform destination;
	private NavMeshAgent navComp;
	
	void Start () 
	{
		navComp = GetComponent <NavMeshAgent>();
	}

	void Update () 
	{
		navComp.SetDestination(destination.position);
		/*if (destination.position = null) 
		{
			destination.position = new Vector3(0,0,0);
		}*/
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "crime")
		{
			destination.position = new Vector3(0,0,0);
			Destroy(other.gameObject);
			randomInstance.count--;
		}
	}
}
