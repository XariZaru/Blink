using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    Vector2 startPosition;
    Vector2 currentPosition;
    private int distance = 50;

	// Use this for initialization
	void Start () {
        startPosition = new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        currentPosition = new Vector2(transform.position.x, transform.position.y);

        if (currentPosition.x - startPosition.x > distance || currentPosition.y - startPosition.y > distance)
        {
            Destroy(gameObject);
        }
    }

}
