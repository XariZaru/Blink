using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : NetworkManager {
    
    public GameObject player;


	// Use this for initialization
	void Start () {        
        
        NetworkClient client = new NetworkClient();
        client.Connect("25.1.50.65", 8484);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void RegisterPrefabs()
    {
        ClientScene.RegisterPrefab(player);
    }
}
