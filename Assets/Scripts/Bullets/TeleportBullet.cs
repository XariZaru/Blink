using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TeleportBullet : MonoBehaviour
{

    Vector2 startPosition;
    Vector2 currentPosition;
	Vector2 direction;
    private int distance = 50;
    private GameObject shooter;
    public static readonly float bullet_speed = 10f;
	public int bounces = 2;

    // Use this for initialization
    void Start()
    {
        startPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setShooter(GameObject shooter)
    {
        this.shooter = shooter;
    }

    public GameObject getShooter()
    {
        return shooter;
    }

	public void setDirection(Vector2 direction)
	{
		this.direction = direction;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Map"))
        //{
        //    DestroyObject();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Map"))
        {
            if (bounces == 0)
                DestroyObject();
            else
            {
                direction = Vector2.Reflect(direction, collision.contacts[0].normal);
                gameObject.GetComponent<Rigidbody2D>().velocity = direction * bullet_speed;
                bounces--;
            }
        }
    }

    public void DestroyObject()
    {
        shooter.GetComponent<PlayerController>().canShootTeleportBullet();
        NetworkServer.Destroy(gameObject);
    }
}
