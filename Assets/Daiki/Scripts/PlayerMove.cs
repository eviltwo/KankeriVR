using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed = 2f;
	public float rotSpeed = 30f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 axis = new Vector3 (
			               Input.GetAxis ("Horizontal"),
			               0,
			               Input.GetAxis ("Vertical"));
		transform.position += axis * moveSpeed * Time.deltaTime;
		transform.Rotate (
			0,
			axis.x * rotSpeed * Time.deltaTime,
			0);
	}
}
