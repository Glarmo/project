using UnityEngine;
using System.Collections;

public class movingGUI : MonoBehaviour 
{	
	private int guiX;
	private int guiY;
	private string textNew;

	void Start ()
	{
		guiX = Screen.width;
		guiY = 100;
		if (movement.solvedCrime == true)
		{
			textNew = "The city is a little bit safer";
			movement.solvedCrime = false;
		}
		else
		{
			textNew = "They got away";
			movement.failedCrime = false;
		}
	}

	void Update ()
	{
		if (movement.solvedCrime == true || movement.failedCrime == true)
		{
			print ("level 1");
			while ( guiY > guiY + 55)
			{
				print ("Level 2");
				guiY--;
			}
		}
	}
	void OnGUI ()
	{
		guiX -= 4;
		if (guiX < 1000)
		{
			guiX = 1000;
		}

		if (GUI.Button (new Rect (guiX, 100, 170, 50), "" + textNew))
		{
			Destroy(gameObject);
		}
	}
}
