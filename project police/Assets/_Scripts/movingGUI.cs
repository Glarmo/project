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
		guiY = guiYOG;
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
		print (notificationKeep);
		print (movement.notificationCheck);
		if (notificationKeep < movement.notificationCheck)
		{
			guiY += 4;
			if (guiY > guiYOG + 55)
			{
				guiYOG = guiYOG + 55;
				notificationKeep = movement.notificationCheck;
			}
		}
		if (randomInstance.destroyedGUICheck == true)
		{
			if (guiY > randomInstance.destroyedGUIHeight)
			{
				guiY -= 4;
				if (guiY > guiYOG + 55)
				{
					guiYOG = guiYOG + 55;
				}
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

		if (GUI.Button (new Rect (guiX, guiY, 170, 50), "" + textNew))
		{
			randomInstance.destroyedGUICheck = true;
			randomInstance.destroyedGUIHeight = guiY;
			Destroy(gameObject);
		}
	}
}
