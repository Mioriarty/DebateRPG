using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Entity {

	public static Player i; // Singleton
	void Awake(){
		i = this;
	}

	public float jumpForce = 10;

	private bool isGrounded = false;
	private bool swordEquiped = false;

	private bool jumped = false;

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Animator animator;

	[SerializeField]
	private Transform groundDetector1;
	[SerializeField]
	private Transform groundDetector2;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponentInChildren<SpriteRenderer> ();
		animator = GetComponentInChildren<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		// Grounded Test
		Collider2D c = Physics2D.OverlapArea(Utils.vec3To2(groundDetector1.position), Utils.vec3To2(groundDetector2.position));
		isGrounded = c != null && c.tag != "Player";
		animator.SetBool ("grounded", isGrounded);


	}

	void FixedUpdate(){
		// Move
		Vector2 velo = Vector2.zero;
		velo.y = rb.velocity.y;

		if (InputController.isButtonDown (GameButton.LEFT)) {
			velo.x = speed * -1;
			facingRight = false;
		}
		if (InputController.isButtonDown (GameButton.RIGHT)) {
			velo.x += speed;
			facingRight = true;
		}
		animator.SetBool ("moving", velo.x != 0);
		//animator.SetBool ("swordEquiped", swordEquiped);
		rb.velocity = velo;
		if (!jumped) {
			if (InputController.isButtonJustDown (GameButton.JUMP) && isGrounded) {
				velo.y = 0;
				rb.velocity = velo;
				rb.AddForce (Vector2.up * jumpForce);
				Dialogue.i.requestClick ();
				jumped = true;
			}
		} else {
			jumped = false;
		}

		// Flip
		sr.flipX = !facingRight;
	}


	void OnTriggerEnter2D(Collider2D c){
		switch (c.gameObject.tag) {
		case "EnemyGroop":
			List<GameObject> children = new List<GameObject> ();
			foreach (Transform t in c.gameObject.transform) {
				children.Add (t.gameObject);
			}
			BattleStarter.initBattle (this, children.ToArray ());
			break;
		case "NPC":
			c.gameObject.GetComponent<NPC> ().playerEnters ();
			break;
		}
	}

	void OnTriggerExit2D(Collider2D c){
		switch (c.gameObject.tag) {
		case "NPC":
			c.gameObject.GetComponent<NPC> ().playerExits ();
			break;
		}
	}

	public void prepareForBattle(){
		animator.SetBool ("grounded", true);
		animator.SetBool ("swordEquiped", true);
		animator.SetBool ("moving", false);
		gameObject.GetComponent<PlayerBattle> ().enabled = true;
		rb.simulated = false;
		enabled = false;
	}


	
}
