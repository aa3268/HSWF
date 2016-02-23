using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;
	public Sprite health4;
	public Sprite health3;
	public Sprite health2;
	public Sprite health1;
	public Sprite health0;
	public Text text;

	public SpriteRenderer health_bar;
	public int health;

	public bool canJump;
	public bool detach;

	[Range(0.1f, 2.0f)]
	public float speed = 0.1f;

	public Rigidbody2D body;

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


	public AudioSource src;
	public AudioSource bg;
	public AudioClip lostHealthClip;
	public AudioClip winState;
	public AudioClip deathState;

	// Use this for initialization
	void Start () {
		health = 4;
		canJump = true;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateHealth ();
		Controls ();

		if(health == 0)
		{
			bg.Stop();
			text.text = "You died.";
			panel.SetActive(true);
			bg.PlayOneShot(deathState);
			this.enabled = false;
		}
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
		//animator.SetTrigger ("Idle");
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


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Floor")) {
			canJump = true;
		}
		if (col.gameObject.tag.Equals ("Bullet")) {
			Destroy (col.gameObject);
			if (health > 0) {
				health--;
				if(!src.isPlaying)
				{
					src.PlayOneShot(lostHealthClip);
				}
			
			}
		}

		if(col.gameObject.tag.Equals("AotC"))
		{
			bg.Stop();
			panel.SetActive(true);
			bg.PlayOneShot(winState);
			this.enabled = false;
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

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Floor")) {
			canJump = false;
		}
	}
}
