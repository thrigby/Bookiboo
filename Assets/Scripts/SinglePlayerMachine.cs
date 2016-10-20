using UnityEngine;
using System.Collections;
//using Prototype.NetworkLobby;
using UnityEngine.Networking;


public class SinglePlayerMachine : NetworkBehaviour {

public SpawnManager spawnManager;

	void Start()
	{
//    	spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager> ();
 	   	CmdSpawnEnemy();
	}

//	public int resetMaxPlayers;

	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
		Network.maxConnections = 0;
//		Network.
//		resetMaxPlayers = GetComponent<NetworkLobbyManager>();
//		resetMaxPlayers. = 1;
	}

[Command]
void CmdSpawnEnemy()
{


    // Set up enemy on server
    var enemy = spawnManager.GetFromPool(transform.position + transform.forward);

//    enemy.GetComponent<Rigidbody>().velocity = transform.forward*4;
    
    // spawn enemy on client, custom spawn handler will be called
    NetworkServer.Spawn(enemy, spawnManager.assetId);
    enemy.SetActive(true);
				Debug.Log ("Enemy Spawned");      
    // when the enemy is destroyed on the server it wil automatically be destroyed on clients
//    StartCoroutine (Destroy (enemy, 2.0f));
}

}
