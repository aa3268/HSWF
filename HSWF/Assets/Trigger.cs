using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public Camera cam;
	public bool follow;
	public GameObject spark;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (follow) {
			cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0f,0f, cam.transform.localPosition.z), Time.deltaTime);
		}
	}



	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			spark.SetActive(true);
			follow = true;
			cam.transform.parent = spark.transform;
		}
	}
}
