 using UnityEngine;
using System.Collections;

public class clicker : MonoBehaviour 
{
    void OnMouseOver ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
            randomInstance.count--;
        }
    }
}
