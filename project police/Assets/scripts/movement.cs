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
		//target = GameObject.Find(transform;
		if (target) 
		{
			navComp.SetDestination(target.position);
		}
	}
}
