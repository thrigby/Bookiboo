using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook {

	public override void OnLobbyServerSceneLoadedForPlayer (NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
		{
			LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
			SealControl2 localPlayer = gamePlayer.GetComponent<SealControl2>();

			localPlayer.name = lobby.playerName;
			localPlayer.playerColor = lobby.playerColor;
		}

}
