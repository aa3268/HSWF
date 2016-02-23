using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public Camera cam;
	public bool follow;
	public GameObject spark;
	public bool triggered;
	// Use this for initialization
	void Start () {
		triggered = false;
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Player") && !triggered) 
		{
			triggered = true;
			spark.SetActive(true);
			cam.transform.parent = spark.transform;
		}
	}
}
