using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadPrefabs : MonoBehaviour {

	public GameObject bullet, teleportBullet, enemy;
    public float spawnTime = 3.0f;
    public Transform[] spawnPoints;
    public float timer;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

    void Spawn()
    {

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        var spawnPosition = spawnPoints[spawnPointIndex];
        GameObject new_enemy = Instantiate(enemy, spawnPosition.position, spawnPosition.rotation);
    }

    // Update is called once per frame
    void Update () {
        timer = Time.timeSinceLevelLoad;

        if (30.0f >= timer && timer > 15.0f)
        {
            spawnTime = 2.5f;
        }

        if (60.0f >= timer && timer > 30.0f)
        {
            spawnTime = 2.0f;
        }

        if (timer > 60.0f)
        {
            spawnTime = 1.0f;
        }
    }
}
