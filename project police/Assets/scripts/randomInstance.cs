using UnityEngine;
using System.Collections;

public class randomInstance : MonoBehaviour
{
    public GameObject marker;
    public Vector3 mapLimits;
	public static int unitCount = 100;
    public static int crimeCount;

	private int chance;
    

	void Update ()
    {
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
