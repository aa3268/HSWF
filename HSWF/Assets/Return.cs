﻿using UnityEngine;
using System.Collections;

public class Return : MonoBehaviour {
	
	public Camera cam;
	public GameObject player;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals ("End")) {
			cam.transform.parent = player.transform;
			Destroy(gameObject);
		}
	}
}