using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
	public bool GUIenabled = true;
	public string CurrentMenu = "MainMenu";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{

		if (CurrentMenu == "MainMenu")
			MenuGUI ();
		if (CurrentMenu == "Instructions")
			InstructionsGUI ();
		if (CurrentMenu == "Quit")
			Application.Quit ();
		/*if (CurrentMenu == "EndWin" || CurrentMenu == "EndLose")
			EndGameGUI ();*/

	}

	void MenuGUI()
	{
		GUI.Box (new Rect (280, 120, (Screen.width / 4) + 200, (Screen.height / 4) + 250), "Blink");
		if (GUI.Button (new Rect (370, 360, 120, 25), "Start Game")) 
		{
			SceneManager.LoadScene ("Main");
			GUIenabled = false;
		}

		if (GUI.Button (new Rect (510, 360, 120, 25), "Instructions")) 
		{
			CurrentMenu = "Instructions";
		}
		if (GUI.Button (new Rect (650, 360, 120, 25), "Quit")) 
		{
			CurrentMenu = "Quit";
		}
	}
	void InstructionsGUI()
	{
		GUI.Box (new Rect (280, 120, (Screen.width / 4) + 200, (Screen.height / 4) + 250), "Instructions");
		GUI.Label (new Rect (300, 150, (Screen.width / 4) + 180, (Screen.height / 4) + 220), "Use the WASD keys to move the player around.\nLeft click to shoot regular" +
		"bullets and right click to shoot teleportation bullets.\nRegular bullets will kill the enemy it comes in contact with\nTeleportation bullets allow the user " +
		"to instantly swap positions by right clicking a second time.");
		if (GUI.Button (new Rect (500, 410, 120, 75), "Close")) {
			GUIenabled = true;
			CurrentMenu = "MainMenu";
		}
	}
	/*void EndGameGUI()
	{
		if (CurrentMenu == "EndWin") 
		{
			GUI.Box (new Rect (280, 120, (Screen.width / 4) + 200, (Screen.height / 4) + 250), "You Win!");
		}
		if (CurrentMenu == "EndLose") 
		{
			GUI.Box (new Rect (280, 120, (Screen.width / 4) + 200, (Screen.height / 4) + 250), "You Have Died!");
		}
		if (GUI.Button (new Rect (370, 360, 120, 25), "Play again")) 
		{
			SceneManager.LoadScene ("Main");
			//GUIenabled = false;
		}

		if (GUI.Button (new Rect (510, 360, 120, 25), "Main Menu")) 
		{
			CurrentMenu = "MainMenu";
		}
	}*/

}
