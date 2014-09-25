 using UnityEngine;
using System.Collections;

public class clicker : MonoBehaviour 
{
   // GameObject get = GameObject.Find("randomInstance");
    void OnMouseOver ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
            //get.count --;
            randomInstance.count--;
        }
    }
}
