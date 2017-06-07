using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject bulletPrefab, teleportBulletPrefab;
    float speed = .15f;
    float bulletSpeed = 20.0f;
    float fireRate = 0.50f;
    float lastShot = 0.0f, lastTeleportShot = 0.0f;
    private bool canShootTeleport = true;
    private GameObject teleportShot = null;
   

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

        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 curPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = target - curPos;
        direction.Normalize();

        // Left Click
        if (Input.GetMouseButton(0))
        {
            if (Time.time > fireRate + lastShot)
            {                
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);
                GameObject projectile = (GameObject)Instantiate(bulletPrefab, curPos, transform.rotation *= Quaternion.Euler(0, 0, 270));

                Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

                projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                lastShot = Time.time;
            } 
        }

        // Right Click 
        if (Input.GetMouseButtonDown(1))
        {
            if (teleportShot != null)
            {
                gameObject.transform.position = teleportShot.transform.position;
                teleportShot.GetComponent<TeleportBullet>().DestroyObject();
                teleportShot = null;
            }
            else if (canShootTeleport)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);
                GameObject projectile = (GameObject)Instantiate(teleportBulletPrefab, curPos, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * TeleportBullet.bullet_speed;
                projectile.GetComponent<TeleportBullet>().setShooter(gameObject);
                canShootTeleport = false;
                teleportShot = projectile;
            }
        }
    }

    public void canShootTeleportBullet()
    {
        canShootTeleport = true;
        teleportShot = null;
    }

    void FixedUpdate()
    {


    }

    void OnCollisionEnter2D(Collision2D other)
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float xDistance = other.gameObject.transform.position.x - gameObject.transform.position.x;
        float yDistance = other.gameObject.transform.position.y - gameObject.transform.position.y;

        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            NetworkServer.Destroy(gameObject);
        }
    }
}

