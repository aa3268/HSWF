using UnityEngine;
using System.Collections;

public class EnemyAiRanged : MonoBehaviour {

	public float range;

	public GameObject left;
	public GameObject right;
	public float lx;
	public float rx;

	public float position;
	public float start;

	[Range(1.0f, 5.0f)] 
	public float timer = 1.0f;

	[Range(0.1f, 1.0f)] 
	public float speed = 1.0f;

	float timerO;
	public bool move;


	[Range(1.0f, 3.0f)]
	public float cooldown = 1f;
	float cooldownO;

	public enum State {IDLE = 0, ATTACK = 1};
	public State current;

	public GameObject player;
	public GameObject gun;
	public GameObject bullet;


	void Start () {
		cooldownO = cooldown;
		current = State.IDLE;
		move = false;
		timerO = timer;
		lx = left.transform.position.x;
		rx = right.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (current == State.IDLE) {
			Idle ();
		} else if (current == State.ATTACK) {
			Attack();
		}
	}

	void Idle()
	{
		if (timer > 0) {
			timer -= Time.deltaTime;
		} else {
			if(!move)
			{
				position = Random.Range(lx, rx);
				start = transform.position.x;
				move = true;
			}
			Move();
		}
	}
	void Move()
	{
		if (move) {
			if (position > start) {
				transform.eulerAngles = new Vector3(0f, 0f,0f);
				//transform.localScale = new Vector3(1.3f, transform.localScale.y, transform.localScale.z);
				transform.Translate (Vector3.right * speed);
				if (transform.position.x > position) {
					move = false;
					timer = timerO;
				}
			} 

			if (position < start) {
				transform.eulerAngles = new Vector3(0f, 180f,0f);
				//transform.localScale = new Vector3(-1.3f, transform.localScale.y, transform.localScale.z);
				transform.Translate (Vector3.right * speed);
				if (transform.position.x < position) {
					move = false;
					timer = timerO;
				}
			}
		}
	}



	void Attack()
	{
		if(player.transform.position.x > transform.position.x)
		{
			transform.eulerAngles = new Vector3(0f, 0f,0f);
			//transform.localScale = new Vector3(1.3f, transform.localScale.y, transform.localScale.z);
		}
		else
		{
			transform.eulerAngles = new Vector3(0f, 180f,0f);
			//transform.localScale = new Vector3(-1.3f, transform.localScale.y, transform.localScale.z);
		}
		Shoot();
	}
	void Shoot()
	{
		if (cooldown >= cooldownO ) {
			cooldown = 0;
			Instantiate(bullet, gun.transform.position, gun.transform.rotation);
		} else {
			cooldown += Time.deltaTime;
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log (col.gameObject.name);
		if (col.gameObject.tag.Equals ("Player")) {
			current = State.ATTACK;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		current = State.IDLE;
	}
}
