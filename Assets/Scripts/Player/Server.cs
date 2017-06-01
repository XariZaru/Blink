using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NetworkServer.Listen("25.1.50.65", 8484);        
        NetworkServer.SpawnObjects();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
