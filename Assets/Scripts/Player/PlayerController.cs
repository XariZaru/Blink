using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject bulletPrefab;
    float speed = .2f;
    float bulletSpeed = 100.0f;
    float fireRate = 0.5f;
    float lastShot = 0.0f;
   

	// Use this for initialization
	void Start () {        

	}
	
	// Update is called once per frame
	void Update () {
        if (!hasAuthority)
            return;

        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.position += movement * speed;


        if (Input.GetMouseButton(0))
        {
            if (Time.time > fireRate + lastShot)
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector2 curPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction = target - curPos;
                direction.Normalize();
                Quaternion rotatio = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);
                GameObject projectile = (GameObject)Instantiate(bulletPrefab, curPos, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                lastShot = Time.time;
            }
            
        }
    }

    void FixedUpdate()
    {
        

    }
    
}

