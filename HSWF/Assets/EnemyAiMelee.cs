using UnityEngine;
using System.Collections;

public class EnemyAiMelee : MonoBehaviour {
	
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
	public bool hit;


	void Start () {
		hit = false;
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
				transform.eulerAngles = new Vector3(0f, 90f,0f);
				transform.Translate (Vector3.forward * speed);
				if (transform.position.x > position) {
					move = false;
					timer = timerO;
				}
			} 
			
			if (position < start) {
				transform.eulerAngles = new Vector3(0f, -90f,0f);
				transform.Translate (Vector3.forward * speed);
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
			transform.eulerAngles = new Vector3(0f, 90f,0f);
		}
		else
		{
			transform.eulerAngles = new Vector3(0f, -90f,0f);
		}
		Charge ();
	}
	void Charge()
	{
		if (current == State.ATTACK) {
			if(player.transform.position.x > transform.position.x)
			{
				transform.eulerAngles = new Vector3(0f, 90f,0f);
			}
			else
			{
				transform.eulerAngles = new Vector3(0f, -90f,0f);
			}

			if(!hit)
			{
				transform.Translate(Vector3.forward * speed * 2.0f);
			}
		}
	}
	
	
	void OnTriggerEnter(Collider col)
	{
		Debug.Log (col.gameObject.name);
		if (col.gameObject.tag.Equals ("Player")) {
			current = State.ATTACK;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		current = State.IDLE;
	}

	void OnCollisionEnter(Collision col)
	{
		hit = true;
	}
	void OnCollisionStay(Collision col)
	{
		hit = true;
	}
	void OnCollisionExit(Collision col)
	{
		hit = false;
	}
}
