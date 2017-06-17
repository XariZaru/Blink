using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

	int score = 0;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
		GameObject.Find("Text").GetComponent<Text>().text = "Score: " + score.ToString();
	}

	public void addScore() {
		score++;
	}

	public int getScore() {
		return score;
	}
}
