using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public float distance;
	public GameObject player;

	[Range(0.1f, 2.0f)]
	public float speed = 0.1f;

	public Player ply;
	public bool detached;

	public float height;

	public float pos_x;
	public float pos_y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		detached = ply.detach;
		if (!detached) {
			if (player.transform.position.x > transform.position.x) {
				if (player.transform.position.x - transform.position.x > distance) {
					transform.Translate (Vector3.right * speed);
				}
			}

			if (player.transform.position.x < transform.position.x) {
				if (transform.position.x - player.transform.position.x > distance) {
					transform.Translate (Vector3.left * speed);
				}
			}
		} else {
			pos_x = ply.lastPosX;
			pos_y = ply.lastPosY;

			if(tag.Equals("Follower2"))
			{
				transform.position = new Vector3(pos_x, pos_y + height, transform.position.z);
			}
			else
			{
				transform.position = new Vector3(pos_x, pos_y, transform.position.z);
			}
		}

	}
}
