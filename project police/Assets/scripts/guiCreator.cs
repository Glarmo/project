using UnityEngine;
using System.Collections;

public class guiCreator : MonoBehaviour 
{
    public Texture background;
    void OnGUI ()
    {
        GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height/10), background, ScaleMode.StretchToFill, true, 0);         //Top bar
        GUI.DrawTexture (new Rect(0, 0, Screen.width/50, Screen.height), background, ScaleMode.StretchToFill, true, 0);         //Left bar
        GUI.DrawTexture (new Rect(Screen.width - Screen.width/50, 0, Screen.width, Screen.height), background, ScaleMode.StretchToFill, true, 0);           //Right bar
        GUI.DrawTexture (new Rect(0, Screen.height - Screen.height/50, Screen.width, Screen.height), background, ScaleMode.StretchToFill, true, 0);         //Bottom bar

		GUI.Label (new Rect(10, 10, 100, 100), "Units: " + randomInstance.unitCount);

    }

}
