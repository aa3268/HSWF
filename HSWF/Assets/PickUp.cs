using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			int health = col.gameObject.GetComponent<Player>().health;

			if(health < 4)
			{
				col.gameObject.GetComponent<Player>().health = health+1;
				
				Destroy(gameObject);
			}

		}
	}
}

