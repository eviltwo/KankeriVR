using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    
	float nomalSpeed = 4.0f;
	float DashSpeed = 12.0f;
	Rigidbody rb;
	bool onGround = false;
	bool touchBoss = false;

	public Camera myCamera;

	// Use this for initialization
	void Start ()
	{
		rb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//float x = Input.GetAxis ("Horizontal");
		//float z = Input.GetAxis ("Vertical");
		//Vector3 direction = new Vector3 (x*moveSpeed, rb.velocity.y, z*moveSpeed);

		var cameraForward = Vector3.Scale (myCamera.transform.forward,
		                                    new Vector3 (1, 0, 1)).normalized;
		Vector3 direction;
		if (Input.GetAxis ("Fire1") == 1) {
			direction = cameraForward * Input.GetAxis ("Vertical") * DashSpeed
				+ myCamera.transform.right * Input.GetAxis ("Horizontal") * DashSpeed;
		} else {
			direction = cameraForward * Input.GetAxis ("Vertical") * nomalSpeed
				+ myCamera.transform.right * Input.GetAxis ("Horizontal") * nomalSpeed;
		}
		direction.y = rb.velocity.y;
		rb.velocity = direction;

		if (onGround) {
			if (Input.GetKeyDown ("space")) {
				direction.y = 320f;
				rb.AddForce (direction);
				onGround = false;
			}
		}
		if (touchBoss) {
			Goal ();
		}

	}

	void OnTriggerStay (Collider collider)
	{
		onGround = true;

	}
	
	void OnCollisionEnter (Collision collider)
	{
		if (collider.gameObject.tag == "Boss") {
			touchBoss = true;
		}
	}

	void Goal ()
	{
		print ("win!!");
	}
}