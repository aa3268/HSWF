using UnityEngine;
using System.Collections;

public class Return : MonoBehaviour {
	
	public Camera cam;
	public GameObject player;

	public GameObject boulders;
	public Animator anim;
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("HIT");
		if (col.gameObject.tag.Equals ("End")) {
			anim.enabled = false;
			cam.transform.parent = player.transform;
			Destroy(boulders);
			Destroy(gameObject);
		}
	}
}