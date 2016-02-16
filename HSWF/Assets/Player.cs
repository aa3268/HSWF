using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {


	public Sprite health4;
	public Sprite health3;
	public Sprite health2;
	public Sprite health1;
	public Sprite health0;

	public SpriteRenderer health_bar;
	public int health;

	public bool canJump;
	public bool detach;

	[Range(0.1f, 2.0f)]
	public float speed = 0.1f;

	public Rigidbody body;

	public float jumpForce;

	public GameObject panel;
	public Image s1;
	public Image s2;
	public Image s3;
	public Image s4;
	public Image s5;

	public Color c;

	public float lastPosX;
	public float lastPosY;

	// Use this for initialization
	void Start () {
		health = 4;
		canJump = true;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateHealth ();
		Controls ();
	}

	void UpdateHealth()
	{
		switch (health) {
		case 4:
			health_bar.sprite = health4;
			break;
		case 3:
			health_bar.sprite = health3;
			break;
		case 2:
			health_bar.sprite = health2;
			break;
		case 1:
			health_bar.sprite = health1;
			break;
		case 0:
			health_bar.sprite = health0;
			break;
		}
	}
	void Controls()
	{
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector3.right * speed);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(Vector3.left * speed);
		}
		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			
			body.AddForce(new Vector3(0f, jumpForce, 0f));
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			lastPosX = transform.position.x;
			lastPosY = transform.position.y;
			detach = !detach;

		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag.Equals ("Floor")) {
			canJump = true;
		}
		if (col.gameObject.tag.Equals ("Bullet")) {
			Destroy (col.gameObject);
			if (health > 0) {
				health--;
			}
		}

		if(col.gameObject.tag.Equals("AotC"))
		{
			panel.SetActive(true);
		}

		if(col.gameObject.tag.Equals("Pic1"))
	   	{
			c = s1.color;
			c.a = 1;
			c.r = 1;
			c.g = 1;
			c.b = 1;
			s1.color = c;
			col.gameObject.SetActive(false);
		}
		if(col.gameObject.tag.Equals("Pic2"))
		{
			c = s2.color;
			c.a = 1;
			c.r = 1;
			c.g = 1;
			c.b = 1;
			s2.color = c;
			col.gameObject.SetActive(false);
		}
		if(col.gameObject.tag.Equals("Pic3"))
		{
			c = s3.color;
			c.a = 1;
			c.r = 1;
			c.g = 1;
			c.b = 1;
			s3.color = c;
			col.gameObject.SetActive(false);
		}
		if(col.gameObject.tag.Equals("Pic4"))
		{
			c = s4.color;
			c.a = 1;
			c.r = 1;
			c.g = 1;
			c.b = 1;
			s4.color = c;
			col.gameObject.SetActive(false);
		}
		if(col.gameObject.tag.Equals("Pic5"))
		{
			c = s5.color;
			c.a = 1;
			c.r = 1;
			c.g = 1;
			c.b = 1;
			s5.color = c;
			col.gameObject.SetActive(false);
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag.Equals ("Floor")) {
			canJump = false;
		}
	}
}
