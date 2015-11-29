using UnityEngine;
using System.Collections;

public class BossBody : MonoBehaviour {

    public GameObject Boss;
    private Quaternion XPos;
    private Quaternion ZPos;

	// Use this for initialization
	void Start () {
        XPos.x = 0;
        ZPos.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}
