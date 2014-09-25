using UnityEngine;
using System.Collections;

public class keepOnScreen : MonoBehaviour 
{
    Vector3 screenPos;
	void Update ()
    {
         screenPos = camera.WorldToScreenPoint(transform.position);
         transform.position = screenPos;
	}

}
