using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool canJump;

	[Range(0.1f, 2.0f)]
	public float speed = 0.1f;

	public Rigidbody body;

	[Range(100f, 250.0f)]
	public float jumpForce;

	// Use this for initialization
	void Start () {
		canJump = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector3.right * speed);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(Vector3.left * speed);
		}


		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			canJump = false;
			body.AddForce(new Vector3(0f, jumpForce, 0f));
		}
	}


	void OnColliderEnter(Collider col)
	{
		if (col.gameObject.tag.Equals ("Floor")) {
			canJump = true;
		}
	}
}
