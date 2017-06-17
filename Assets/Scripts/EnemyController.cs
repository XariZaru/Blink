using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour {
    public float speed;
    public int distance;
    public int score = 0;
    float bulletSpeed = 20.0f;
    float fireRate = 1f;
    float lastShot = 0.0f;

    public GameObject player;
    public GameObject bulletPrefab;
    public Text scoretext;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if (player == null)
			player = GameObject.Find ("Player");

        transform.right = player.transform.position - transform.position;
        var direction = transform.right;

        if ((transform.position - player.transform.position).sqrMagnitude > distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if (Time.time > fireRate + lastShot)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            GameObject projectile = (GameObject)Instantiate(bulletPrefab, transform.position, rotation);
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            lastShot = Time.time;
        }

    }

	void OnTriggerEnter2D(Collider2D other)
	{
		/*
		if (other.gameObject.CompareTag("Bullet"))
		{
			GameObject score_board = GameObject.Find ("Scoreboard");
			score_board.GetComponent<Scoreboard> ().addScore ();
            //score += 1;
            //scoretext.gameObject.GetComponent<Text>().text = score.ToString();
			Destroy(gameObject);
		}
		*/
	}
}
