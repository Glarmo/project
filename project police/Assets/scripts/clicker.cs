using UnityEngine;
using System.Collections;

public class clicker : MonoBehaviour 
{
	public GameObject policeCar;

    void OnMouseOver ()
    {
        if (Input.GetMouseButtonDown(0))
        {
			Vector3 spawnPosition = new Vector3 (0,0,0);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (policeCar, spawnPosition, spawnRotation);
            randomInstance.count--;
        }
    }
}
