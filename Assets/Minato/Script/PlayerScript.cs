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
	
	float Energy = 5.0f;
	bool dashAble = false;

	// Use this for initialization
	void Start ()
	{
		rb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Energy += Time.deltaTime;
		if(Energy >= 5){
			dashAble = true;
			Energy -= Time.deltaTime;
		}
		if(Energy <= 0){
			dashAble = false;
			Energy += Time.deltaTime;
		}
		var cameraForward = Vector3.Scale (myCamera.transform.forward,
		                                    new Vector3 (1, 0, 1)).normalized;
		Vector3 direction = Walk (cameraForward);
		
		if(dashAble == true){
			if(Input.GetAxis("Fire1") == 1){
				Dash(cameraForward);
				Energy -= Time.deltaTime*2;
				print (Energy);
				if(Energy <= 0){
					dashAble = false;
				}
			}
		}

		direction.y = rb.velocity.y;
		rb.velocity = direction;

		if (onGround) {
			if (Input.GetKeyDown ("space")) {
				direction.y = 350f;
				rb.AddForce (direction, ForceMode.Force);
				onGround = false;
			}
		}
		if (touchBoss) {
			Goal ();
		}

	}

	Vector3 Walk (Vector3 cameraForward)
	{
		Vector3 direction = cameraForward * Input.GetAxis ("Vertical") * nomalSpeed
			+ myCamera.transform.right * Input.GetAxis ("Horizontal") * nomalSpeed;
		return direction;
	}

	Vector3 Dash (Vector3 cameraForward)
	{
		Vector3 direction = cameraForward * Input.GetAxis ("Vertical") * DashSpeed
			+ myCamera.transform.right * Input.GetAxis ("Horizontal") * DashSpeed;
		return direction;
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