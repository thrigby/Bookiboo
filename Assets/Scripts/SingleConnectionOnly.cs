using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SingleConnectionOnly : MonoBehaviour {

	public void BlockOtherConnections ()
	{
		GetComponentInParent<NetworkLobbyManager>().maxPlayers = 1;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
