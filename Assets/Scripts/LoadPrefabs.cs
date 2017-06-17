using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadPrefabs : MonoBehaviour {

	public GameObject bullet, teleportBullet, enemy;

	// Use this for initialization
	void Start () {
		ClientScene.RegisterPrefab (bullet);
		ClientScene.RegisterPrefab (teleportBullet);
	}
	
	// Update is called once per frame
	void Update () {
		int number_enemies = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		int to_spawn = 10 - number_enemies;
		Debug.Log (to_spawn);
		for (int x = 0; x < to_spawn; x++) {
			int x_coord = 24;
			int y_coord = Random.Range (-20, 20);
			GameObject new_enemy = Instantiate(enemy, new Vector3(x_coord, y_coord, 0), Quaternion.identity);
		}
	}
}
