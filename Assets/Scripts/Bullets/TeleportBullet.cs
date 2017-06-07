using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TeleportBullet : MonoBehaviour
{

    Vector2 startPosition;
    Vector2 currentPosition;
    private int distance = 50;
    private GameObject shooter;
    public static readonly float bullet_speed = 10f;

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


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            DestroyObject();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        shooter.GetComponent<PlayerController>().canShootTeleportBullet();
        NetworkServer.Destroy(gameObject);
    }

}
