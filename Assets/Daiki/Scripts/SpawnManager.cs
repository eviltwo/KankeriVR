using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
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

	//ButtonStartHostボタンを押した時に実行
	//IPポートを設定し、ホストとして接続
	public void StartupHost()
	{
		SetPort();
		NetworkManager.singleton.StartHost();
	}

	//ButtonJoinGameボタンを押した時に実行
	//IPアドレスとポートを設定し、クライアントとして接続
	public void JoinGame()
	{
		SetIPAddress();
		SetPort();
		NetworkManager.singleton.StartClient();
	}

	void SetIPAddress()
	{
		//Input Fieldに記入されたIPアドレスを取得し、接続する
		string ipAddress = GameObject.Find("InputFieldIPAddress").transform.FindChild("Text").GetComponent<Text>().text;
		NetworkManager.singleton.networkAddress = ipAddress;
	}

	//ポートの設定
	void SetPort ()
	{
		NetworkManager.singleton.networkPort = 7777;
	}
}
