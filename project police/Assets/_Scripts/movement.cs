using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
	public Transform destination;
	public GameObject notificationGUI;

	public static bool solvedCrime = false;
	public static bool failedCrime = false;
	public static int notificationCheck = 1;

	private int spawnTime = 60;
	private int successChance;
	private int crimeTime;
	private Ray carRay;
	private RaycastHit carHit;
	private bool complete = false;
	private bool selected = false;
	private NavMeshAgent navComp;
	
	void Start () 
	{
		crimeTime = Random.Range (2, 20);
		successChance = clicker.successChanceGUI;
		navComp = GetComponent <NavMeshAgent>();
		StartCoroutine (policeTimer());
	}

	void Update () 
	{
		if (destination == null || complete == true)
		{
			destination = GameObject.FindGameObjectWithTag("ReturnPoint").GetComponent<Transform>();
			notificationGUI = GameObject.FindGameObjectWithTag("movingGUI");
			complete = true;
		}

		if (selected == true && Input.GetMouseButtonDown (0))
		{
			/*carRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(carRay, out carHit))
			{
				if (carHit.transform.name == "Map Collider")
				{
					destination = carHit.transform;
					print (carHit);
					if (!navComp.pathPending)
					{
						if (navComp.remainingDistance <= navComp.stoppingDistance)
						{
							if (!navComp.hasPath || navComp.velocity.sqrMagnitude == 0.5f)
							{
								print("here");
								// Done
							}
						}
					}
				}
			}*/
		}

		navComp.SetDestination(destination.position);		//Sets destination 
	}
	

	IEnumerator OnTriggerEnter(Collider other) 
	{
		if (other.tag == "crime")
		{
			Vector3 notificationSpawn = new Vector3 (0, 0);
			Quaternion notificationRotation = Quaternion.identity;
			int chance = Random.Range (0, 100);				
			yield return new WaitForSeconds (crimeTime);
			if (chance < successChance)		//Success
			{
				notificationCheck++;
				Destroy(other.gameObject);
				randomInstance.crimeCount--;	
				destination = GameObject.FindGameObjectWithTag("ReturnPoint").GetComponent<Transform>();
				complete = true;			//Tells the GM that it has completed the task
				Instantiate (notificationGUI, notificationSpawn, notificationRotation);
				solvedCrime = true;
				randomInstance.money+=100;
			}
			if (chance > successChance)		//Failed the crime
			{
				notificationCheck++;
				Destroy(other.gameObject);
				Instantiate (notificationGUI, notificationSpawn, notificationRotation);
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

	IEnumerator policeTimer ()
	{
		yield return new WaitForSeconds (spawnTime);
		Destroy(gameObject);
		randomInstance.unitCount++;
	}

	void OnMouseOver ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			gameObject.renderer.material.color = Color.green;
			selected = true;
		}
	}
}
