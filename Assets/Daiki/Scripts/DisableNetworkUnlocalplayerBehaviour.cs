using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DisableNetworkUnlocalplayerBehaviour : NetworkBehaviour {

	[SerializeField]
	Behaviour[] behaviours;

	void Start ()
	{
		if(! isLocalPlayer ){
			foreach( var behaviour in behaviours ){
				behaviour.enabled = false;
			}
		}
	}

	void OnApplicationFocus(bool focusStatus) {
		if(isLocalPlayer)
		{
			foreach( var behaviour in behaviours ){
				behaviour.enabled = focusStatus;
			}
		}
	}
}
