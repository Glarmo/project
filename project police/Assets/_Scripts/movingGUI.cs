using UnityEngine;
using System.Collections;

public class movingGUI : MonoBehaviour 
{	
	private int guiX;
	private string textNew;

	public movingGUI(string textDisplayed)
	{
		textNew = textDisplayed;
		guiX = Screen.width;
	}
	
	public void Move ()
	{
		guiX--;
		if (GUI.Button (new Rect (guiX, 150, 100, 50), "" + textNew))
		{
		
		}
	}
}
