using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

	public Transform Target;
	public Transform Player;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{

		// get Angle from camera to enemy
		Vector3 targetDir = transform.position - Target.position;
		Vector3 vec = targetDir.normalized;
		Vector3 newPosition = Player.position + new Vector3(vec.x * 5,
		                                                    2,
		                                                    vec.z*5); 
		this.transform.position = newPosition;

		// look at enemy everytime
		transform.LookAt (Target);

	}
}