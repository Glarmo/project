using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
	public Transform target;
	private NavMeshAgent navComp;
	
	void Start () 
	{
		navComp = GetComponent <NavMeshAgent>();
	}

	void Update () 
	{
		if (target) 
		{
			navComp.SetDestination(target.position);
		}
	}
}
