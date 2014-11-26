using UnityEngine;
using System.Collections;

public class guiCreator : MonoBehaviour 
{
    public Texture background;
	public GUISkin toolBarSkin;
	public static int doneClicked = 0; 

    void OnGUI ()
    {
		GUI.skin = toolBarSkin;
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height/10), background, ScaleMode.StretchToFill, true, 0);         //Top bar
        GUI.DrawTexture (new Rect(0, 0, Screen.width/50, Screen.height), background, ScaleMode.StretchToFill, true, 0);         //Left bar
        GUI.DrawTexture (new Rect(Screen.width - Screen.width/50, 0, Screen.width, Screen.height), background, ScaleMode.StretchToFill, true, 0);           //Right bar
        GUI.DrawTexture (new Rect(0, Screen.height - Screen.height/50, Screen.width, Screen.height), background, ScaleMode.StretchToFill, true, 0);         //Bottom bar

		GUI.Label (new Rect(50, 20, 100, 50), "Units: " + randomInstance.unitCount);

		if (clicker.crimeClicked == 1) 
		{
			GUI.DrawTexture (new Rect( Screen.width/2 - 100, Screen.height/2 - 30, 200, 100), background, ScaleMode.StretchToFill, true, 0);
			GUI.Label (new Rect (Screen.width/2 - 10, Screen.height/2, 40, 30), "" + randomInstance.unitSend);		//Number of units to be sent

			if (GUI.Button (new Rect (Screen.width/2 - 90, Screen.height/2, 40, 30), "-") && randomInstance.unitSend > 0)		//Take away
			{
				randomInstance.unitSend--;
			}
			if (GUI.Button (new Rect (Screen.width/2 + 50, Screen.height/2, 40, 30), "+") && randomInstance.unitSend < randomInstance.unitCount)		//Pluz
			{
				randomInstance.unitSend++;
			}
			if (GUI.Button (new Rect (Screen.width/2 + 50, Screen.height/2 + 40, 40, 20), "Go")) 		//Done
			{
				doneClicked = 1;
				randomInstance.unitSend = 0;
				clicker.crimeClicked = 0;
			}
		}
    }

}
