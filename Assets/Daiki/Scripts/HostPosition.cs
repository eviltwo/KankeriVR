using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class HostPosition : NetworkBehaviour {
	public Vector3 hostPosition;
	// Use this for initialization
	void Start () {
		if (isServer) {
			transform.position = hostPosition;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
