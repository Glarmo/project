using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
	public Transform destination;
	public float test;
	private NavMeshAgent navComp;
	
	void Start () 
	{
		navComp = GetComponent <NavMeshAgent>();
		print (test);
	}

	void Update () 
	{
		navComp.SetDestination(destination.position);
	}
}
