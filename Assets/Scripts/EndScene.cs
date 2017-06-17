using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{

		GUI.Box (new Rect (280, 120, (Screen.width / 4) + 200, (Screen.height / 4) + 250), "You Win!");
		if (GUI.Button (new Rect (370, 360, 120, 25), "Play Again")) 
			SceneManager.LoadScene ("Main");

		if (GUI.Button (new Rect (510, 360, 120, 25), "Main Menu"))
			SceneManager.LoadScene ("Menu");


	}
}
