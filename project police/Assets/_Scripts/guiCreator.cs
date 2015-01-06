using UnityEngine;
using System.Collections;

public class guiCreator : MonoBehaviour 
{
	public int xTestStart;
	public int yTestStart;
	public int xTestFinish;
	public int yTestFinish;
	public static int doneClicked = 0; 

    public Texture background;
	public Texture menuBackground;
	public Texture unit;
	public Texture money;
	public Texture unitSymbol;

	public GUISkin toolBarSkin;
	public GUISkin plusSkin;
	public GUISkin minusSkin;
	public GUISkin doneSkin;
	public GUISkin storageSkin;
	public GUISkin timeSkin;
	public GUISkin pauseSkin;
	public GUISkin playSkin;
	public GUISkin fastSkin;
	public GUISkin unitSkin;
	public GUISkin menuLabelSkin;

	private bool storageClicked = false;
	private bool unitMenuClicked = false;
	private bool pauseClicked = false;
	private bool playClicked = true;
	private bool fastClicked = false;
	private int unitBuy = 0;


    void OnGUI ()
    {
		//Draws black bars
		GUI.skin = toolBarSkin;
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height/10), background, ScaleMode.StretchToFill, true, 0);         //Top bar
        GUI.DrawTexture (new Rect(0, 0, Screen.width/50, Screen.height), background, ScaleMode.StretchToFill, true, 0);         //Left bar
        GUI.DrawTexture (new Rect(Screen.width - Screen.width/50, 0, Screen.width, Screen.height), background, ScaleMode.StretchToFill, true, 0);           //Right bar
        GUI.DrawTexture (new Rect(0, Screen.height - Screen.height/50, Screen.width, Screen.height), background, ScaleMode.StretchToFill, true, 0);         //Bottom bar

		//Draws money count
		GUI.contentColor = Color.black;
		GUI.DrawTexture (new Rect (20, 24, 100, 50), money, ScaleMode.StretchToFill, true, 0); 			
		GUI.Label (new Rect (55, 36, 50, 30), "" + randomInstance.money);

		//Draws unitcount gui + unit management menus
		GUI.skin = unitSkin;
		unitMenuClicked = GUI.Toggle (new Rect (125, 21, 100, 54), unitMenuClicked, "");
		if (unitMenuClicked == true)
		{
			GUI.skin = menuLabelSkin;
			GUI.contentColor = Color.white;
			GUI.DrawTexture (new Rect (125, 100, 200, 200), menuBackground, ScaleMode.StretchToFill, true, 0);
			GUI.Label (new Rect (140, 115, 100, 20), "WAGE: " + randomInstance.unitWage);
			GUI.skin = minusSkin;
			if (GUI.Button (new Rect(250, 115, 20, 20), ""))
			{
				randomInstance.unitWage -= 10;
			}
			GUI.skin = plusSkin;
			if (GUI.Button (new Rect(280, 115, 20, 20), ""))
			{
				randomInstance.unitWage += 10;
			}
		}
		GUI.contentColor = Color.black;
		GUI.skin = toolBarSkin;
		GUI.Label (new Rect (165, 36, 40, 30), "" + randomInstance.unitCount);

		//Draws time and date
		GUI.contentColor = Color.white;
		GUI.skin = timeSkin;
		GUI.Label (new Rect (30, 5, 110, 20),"" + randomInstance.day + "/" + randomInstance.month + "/" + randomInstance.year + "  " + randomInstance.timeHour + ":" + (int)randomInstance.timeMin);

		//Draws time manipulation tools
		GUI.skin = pauseSkin;
		pauseClicked = GUI.Toggle (new Rect (140, 4, 20, 20), pauseClicked, "");
		if (pauseClicked == true)
	    {
			playClicked = false;
			fastClicked = false;
			Time.timeScale = 0;
		}
		if (playClicked == false && fastClicked == false)
		{
			pauseClicked = true;
		}
		GUI.skin = playSkin;
		playClicked = GUI.Toggle (new Rect (170, 4, 20, 20), playClicked, "");
		if (playClicked == true)
		{
			pauseClicked = false;
			fastClicked = false;
			Time.timeScale = 1;
		}
		GUI.skin = fastSkin;
		fastClicked = GUI.Toggle (new Rect (200, 4, 20, 20), fastClicked, "");
		if (fastClicked == true)
		{
			pauseClicked = false;
			playClicked = false;
			Time.timeScale = 10;
		}

		//Draws storage symbol
		GUI.skin = storageSkin;
		if (GUI.Button (new Rect (1125, 25, 40, 40), ""))
		{
			if (storageClicked == false)
			{
				storageClicked = true;
			}
			else
			{
				storageClicked = false;
			}

		}
		//Draws market tab
		if (storageClicked == true)
		{
			GUI.skin = toolBarSkin;
			GUI.contentColor = Color.white;
			GUI.DrawTexture (new Rect (Screen.width/2 - 200, Screen.height/2 - 250, 400, 500), menuBackground, ScaleMode.StretchToFill, true, 0);
			GUI.Label (new Rect(Screen.width/2 - 50, Screen.height/2 - 245, 100, 40), "MARKET");			//Title

			//Unit Buy
			GUI.DrawTexture (new Rect (425, 200, 21, 34), unitSymbol, ScaleMode.StretchToFill, true, 0);	//Unit Symbol
			GUI.Label (new Rect (450, 205, 230, 30), "$100  ............................");
			GUI.Label (new Rect (712, 210, 40, 20), "" + unitBuy);
			GUI.skin = minusSkin;
			if (GUI.Button (new Rect(685, 210, 20, 20), "") && unitBuy > 0)
			{
				unitBuy--;
			}
			GUI.skin = plusSkin;
			if (GUI.Button (new Rect(760, 210, 20, 20), ""))
			{
				unitBuy++;
			}

			//Done
			GUI.skin = doneSkin;
			if (GUI.Button (new Rect (Screen.width/2 - 10, Screen.height/2 + 200, 20, 20), ""))		
			{
				randomInstance.unitCount = randomInstance.unitCount + unitBuy;
				randomInstance.money = randomInstance.money - (unitBuy * 100);
				storageClicked = false;
				unitBuy = 0;
			}
		}

		//Draws unit send box etc.
		if (clicker.crimeClicked == 1 && storageClicked == false) 
		{
			GUI.skin = toolBarSkin;
			GUI.contentColor = Color.white;
			GUI.DrawTexture (new Rect( Screen.width/2 - 100, Screen.height/2 - 30, 200, 100), menuBackground, ScaleMode.StretchToFill, true, 0);
			GUI.Label (new Rect (Screen.width/2 - 20, Screen.height/2, 40, 30), "" + randomInstance.unitSend);		//Number of units to be sent
			GUI.Label (new Rect (Screen.width/2 - 20, Screen.height/2 - 25, 40, 30), "" + clicker.successChanceGUI + "%");	// chance of success

			GUI.skin = minusSkin;
			if (GUI.Button (new Rect (Screen.width/2 - 90, Screen.height/2, 30, 30), "") && randomInstance.unitSend > 0)		//Take away
			{
				randomInstance.unitSend--;
				clicker.successChanceGUI -= 5;
			}

			GUI.skin = plusSkin;
			if (GUI.Button (new Rect (Screen.width/2 + 60, Screen.height/2, 30, 30), "") && randomInstance.unitSend < randomInstance.unitCount)		//Pluz
			{
				randomInstance.unitSend++;
				clicker.successChanceGUI += 5;
			}

			GUI.skin = doneSkin;
			if (GUI.Button (new Rect (Screen.width/2 - 10, Screen.height/2 + 45, 20, 20), "")) 		//Done
			{
				doneClicked = 1;
				clicker.crimeClicked = 0;
			}
		}
    }
}
