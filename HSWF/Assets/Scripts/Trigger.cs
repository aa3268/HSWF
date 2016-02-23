using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public Camera cam;
	public bool follow;
	public GameObject spark;
	public bool triggered;
	public Animator anim;
	public SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		triggered = false;
	}

	void Update()
	{
		if (sr.sprite.name.Equals ("TNT_Trigger_sprites_3")) {
			anim.enabled = false;
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Player") && !triggered) 
		{
			anim.enabled = true;
			triggered = true;
			spark.SetActive(true);
			cam.transform.parent = spark.transform;
		}
	}
}
