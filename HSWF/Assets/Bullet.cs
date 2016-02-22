using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * 0.2f);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy (gameObject);
	}
}
