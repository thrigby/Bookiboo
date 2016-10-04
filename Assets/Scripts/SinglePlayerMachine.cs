using UnityEngine;
using System.Collections;
//using Prototype.NetworkLobby;
using UnityEngine.Networking;


public class SinglePlayerMachine : NetworkBehaviour {

//	public int resetMaxPlayers;

	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
		Network.maxConnections = 0;
//		resetMaxPlayers = GetComponent<NetworkLobbyManager>();
//		resetMaxPlayers. = 1;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
