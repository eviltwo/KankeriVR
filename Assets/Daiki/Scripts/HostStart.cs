using UnityEngine;
using System.Collections;

public class HostStart : MonoBehaviour {
	public string keyName = "space";
	public SpawnManager spawnManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (keyName)) {
			spawnManager.StartupHost ();
		}
	}
}
