using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SpawnManager : NetworkManager {
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		GameObject player;
		if (conn.connectionId < 0) {
			player = (GameObject)GameObject.Instantiate (spawnPrefabs[1], Vector3.zero, Quaternion.identity);
		} else {
			player = (GameObject)GameObject.Instantiate (spawnPrefabs[0], base.startPositions[Random.Range(0,base.startPositions.Count)].position, Quaternion.identity);
		}
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}
