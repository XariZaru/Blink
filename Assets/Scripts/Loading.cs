using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Loading : MonoBehaviour {

	GameObject bullet, teleportBullet;

	// Use this for initialization
	void Start () {
		ClientScene.RegisterPrefab (bullet);
		ClientScene.RegisterPrefab (teleportBullet);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
