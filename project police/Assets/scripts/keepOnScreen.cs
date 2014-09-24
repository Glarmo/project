using UnityEngine;
using System.Collections;

public class keepOnScreen : MonoBehaviour 
{
    public Transform target;
	void Update ()
    {
         Vector3 screenPos = camera.WorldToScreenPoint(target.position);
         transform.position = screenPos;
	}
}
