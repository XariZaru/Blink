﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletController : MonoBehaviour {

    Vector2 startPosition;
    Vector2 currentPosition;
    private int distance = 50;
	public GameObject owner = null;

	// Use this for initialization
	void Start () {
        startPosition = new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            Destroy(gameObject);
        }

		if (collision.gameObject.CompareTag("Enemy") && owner.Equals(GameObject.FindGameObjectWithTag("Player")))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
			GameObject.Find ("Text").GetComponent<Scoreboard> ().addScore ();
        }
    }
}
