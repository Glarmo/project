using UnityEngine;
using System.Collections;

public class randomInstance : MonoBehaviour
{
    public GameObject marker;
    public Vector2 spawnValues;
    private int random;

	void Update () 
    {

                random = Random.Range(0, 1000);
                if (random < 10)
                {
                    Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y));
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate (marker, spawnPosition, spawnRotation);
                }


	}
}
