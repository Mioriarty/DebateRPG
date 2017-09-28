using UnityEngine;
using System.Collections;

public class Player : Entity {

	public static Player i; // Singleton
	void Awake(){
		i = this;
	}

	public float jumpForce = 10;

	private bool isGrounded = false;

	private Rigidbody2D rb;
	private SpriteRenderer sr;

	private BoxCollider2D groundDetector;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponentInChildren<SpriteRenderer> ();
		groundDetector = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Grounded Test
		isGrounded = groundDetector.IsTouchingLayers();

		// Move
		Vector2 velo = Vector2.zero;
		velo.y = rb.velocity.y;

		if (InputController.isButtonDown (GameButton.LEFT)) {
			velo.x = speed * -1;
			facingRight = false;
		}
		if (InputController.isButtonDown (GameButton.RIGHT)) {
			velo.x = speed;
			facingRight = true;
		}
		rb.velocity = velo;
		if (InputController.isButtonJustDown (GameButton.JUMP) && isGrounded) {
			rb.AddForce(Vector2.up * jumpForce);
		}

		// Flip
		sr.flipX = !facingRight;
	}


	
}
