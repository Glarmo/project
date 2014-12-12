using UnityEngine;
using System.Collections;

public class randomInstance : MonoBehaviour
{
    public GameObject marker;
    public Vector3 mapLimits;
	public static int unitSend = 0;
	public static int unitCount = 100;
    public static int crimeCount;
	public static int money = 1000;

	private int chance;
    

	void Update ()
    {
		Screen.SetResolution (1200, 800, false);
                chance = Random.Range(0, 1000);
                if (chance < 10 && crimeCount < 10)
                {
					Vector3 spawnPosition = new Vector3 (Random.Range (-mapLimits.x, mapLimits.x), 0, Random.Range (-mapLimits.z, mapLimits.z));
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate (marker, spawnPosition, spawnRotation);
                    crimeCount ++;
        		}
	}
    
}
