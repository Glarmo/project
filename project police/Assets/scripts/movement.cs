using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
	public Transform target;
	public clicker targetScript;
	private NavMeshAgent navComp;
	
	void Start () 
	{
		navComp = GetComponent <NavMeshAgent>();
	}

	void Update () 
	{
		target = clicker.targetPosition;
		if (target) 
		{
			navComp.SetDestination(target.position);
		}
	}
}
