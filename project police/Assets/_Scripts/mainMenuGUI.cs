using UnityEngine;
using System.Collections;

public class mainMenuGUI : MonoBehaviour {

	public int xTestStart;
	public int yTestStart;
	public int xSize;
	public int ySize;

	public GUISkin mainMenuSkin;

	void OnGUI () 
	{
		GUI.skin = mainMenuSkin;
		GUI.Label (new Rect (500, 50, 200, 40), "POLICE MANAGER");
		if (GUI.Button (new Rect (560, 275, 80, 20), "START"))
		{
			Application.LoadLevel("test");
		}
		if (GUI.Button (new Rect (570, 325, 60, 20), "QUIT"))
		{
			//quit game
		}
	}
	

}
