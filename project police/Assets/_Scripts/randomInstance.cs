/*! A test class
 */

using UnityEngine;
using System.Collections;

public class randomInstance : MonoBehaviour
{
	public GameObject marker;	/**< target for the police cars */ 
	public GameObject garage;	/**< return point for the cars */
    public Vector3 mapLimits;	/**< limits for the camera */

	public static bool destroyedGUICheck = false;
	public static int destroyedGUIHeight;
	public static int unitSend = 0;
	public static int unitCount = 10;
    public static int crimeCount;
	public static int money = 1000;
	public static int unitWage = 100;
	public static int day = 30;
	public static int month = 12;
	public static int year = 2000;
	public static int timeHour = 23;
	public static int unitSatisfaction = 500;
	public static float timeMin = 50;


	private GameObject building;
	private int chance;
    
	/**< Our starting point */
	void Start ()
	{
		Screen.SetResolution (1200, 800, false);

		//Sets a random building as the police station
		int x = Random.Range (1, 23);
		int y = Random.Range (1, 23);
		building = GameObject.Find ("City/Line " + x + "/Building " + y);
		building.renderer.material.color = Color.blue;
		garage.transform.Translate(new Vector3 (building.transform.position.x + 0.75f, 0, building.transform.position.z));
	}

	void Update ()
    {
		timeMin += Time.deltaTime;
		if (timeMin > 60)
		{			
			timeMin = 0;
			timeHour++;
		}
		if (timeHour > 23)
		{
			timeHour = 0;
			money = money - unitWage * unitCount;	//Deducts wages from money
			unitSatisfaction = unitSatisfaction - 100 + unitWage/2;
			day++;
		}
		if (day > 30)
		{
			day = 1;
			month++;
		}
		if (month > 12)
		{
			month = 1;
			year++;
		}

        chance = Random.Range(0, 1000);
        if (chance < 10 && crimeCount < 10 && guiCreator.pauseClicked == false)
        {
			Vector3 spawnPosition = new Vector3 (Random.Range (-mapLimits.x, mapLimits.x), 0, Random.Range (-mapLimits.z, mapLimits.z));
   		    Quaternion spawnRotation = Quaternion.identity;
    	    Instantiate (marker, spawnPosition, spawnRotation);
         	crimeCount ++;
        }
	}
    
}
