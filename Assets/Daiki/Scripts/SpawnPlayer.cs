using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SpawnPlayer : NetworkBehaviour {
	public GameObject normalPlayerPrefab;
	public GameObject bossPlayerPrefab;
	// Use this for initialization
	void Start () {
		GameObject player;
		player = Instantiate (normalPlayerPrefab);
		NetworkServer.Spawn (player);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
