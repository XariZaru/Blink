using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {


    float speed = .2f;

	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
        //if (!hasAuthority)
        //return;

        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.position += movement * speed;
    }

    void FixedUpdate()
    {
        

    }
    
}
