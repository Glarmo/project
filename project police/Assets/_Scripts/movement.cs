﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
	public Transform destination;

	private int successChance;
	private int crimeTime;
	private bool complete = false;
	private NavMeshAgent navComp;
	
	void Start () 
	{
		crimeTime = Random.Range (2, 15);
		successChance = clicker.successChanceGUI;
		navComp = GetComponent <NavMeshAgent>();
	}

	void Update () 
	{
		if (destination == null || complete == true)
		{
			destination = GameObject.FindGameObjectWithTag("ReturnPoint").GetComponent<Transform>();
			complete = true;
		}

		navComp.SetDestination(destination.position);		//Sets destination 
	}
	

	IEnumerator OnTriggerEnter(Collider other) 
	{
		if (other.tag == "crime")
		{
			int chance = Random.Range (0, 100);
			if (chance < successChance)
			{
				yield return new WaitForSeconds (crimeTime);
				Destroy(other.gameObject);
				randomInstance.crimeCount--;	
				destination = GameObject.FindGameObjectWithTag("ReturnPoint").GetComponent<Transform>();
				complete = true;			//Tells the GM that it has completed the task
				randomInstance.money+=100;
			}
			if (chance > successChance)
			{
				yield return new WaitForSeconds (2);
				destination = GameObject.FindGameObjectWithTag("ReturnPoint").GetComponent<Transform>();
				complete = true;
			}
		}

		if (other.tag == "ReturnPoint" && complete == true) 
		{
			randomInstance.unitCount++;
			Destroy(gameObject);
		}
	}
}
