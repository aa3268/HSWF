using UnityEngine;
using System.Collections;

public class Snap : MonoBehaviour {

	public float x_p;
	public float y_p;
	public float x_t;
	public float y_t;

	public float snapPosY_player;
	public float snapPosX_player;

	public float snapPosY_spark;
	public float snapPosX_spark;


	
	// Update is called once per frame
	void Update () {

		if (transform.parent.tag.Equals ("Player")) {
			if (transform.localPosition.x < x_p && transform.localPosition.x != snapPosX_player) {
				transform.localPosition = new Vector3 (snapPosX_player, transform.localPosition.y, transform.localPosition.z);
			}
			if (transform.localPosition.y < y_p && transform.localPosition.y != snapPosY_player) {
				transform.localPosition = new Vector3 (transform.localPosition.x, snapPosY_player, transform.localPosition.z);
			}

			transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(snapPosX_player,snapPosY_player, transform.localPosition.z), Time.deltaTime);
		} else {
			if (transform.localPosition.x < x_t && transform.localPosition.x != snapPosX_spark) {
				transform.localPosition = new Vector3 (snapPosX_spark, transform.localPosition.y, transform.localPosition.z);
			}
			if (transform.localPosition.y < y_t && transform.localPosition.y != snapPosY_spark) {
				transform.localPosition = new Vector3 (transform.localPosition.x, snapPosY_spark, transform.localPosition.z);
			}
			transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(snapPosX_spark,snapPosY_spark, transform.localPosition.z), Time.deltaTime);
		}
	}	
}
