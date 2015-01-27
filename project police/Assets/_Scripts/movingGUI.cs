using UnityEngine;
using System.Collections;

public class movingGUI : MonoBehaviour 
{	
	private int guiX;
	private int guiY;
	private int guiYOG;
	private int notificationKeep;
	private string textNew;

	void Start ()
	{
		guiX = Screen.width;
		guiYOG = 100;
		guiY = guiY;
		notificationKeep = movement.notificationCheck;
		if (movement.solvedCrime == true)
		{
			textNew = "The city is a little bit safer";
		}
		else
		{
			textNew = "They got away";
		}
	}

	void Update ()
	{
		if (notificationKeep < movement.notificationCheck)
		{
			print("adding");
			guiY += 4;
			if (guiY < guiYOG + 55)
			{
				print ("limit");
				guiY = guiY + 55;
			}
			/*print ("level 1");
			print (guiY);
			print (guiY + 55);
			while ( guiY < guiY + 55)
			{
				print ("Level 2");
				guiY++;
			}*/
		}
	}
	void OnGUI ()
	{
		guiX -= 4;
		if (guiX < 1000)
		{
			guiX = 1000;
		}

		if (GUI.Button (new Rect (guiX, guiY, 170, 50), "" + textNew))
		{
			Destroy(gameObject);
		}
	}
}
