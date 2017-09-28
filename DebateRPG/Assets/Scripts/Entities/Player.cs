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

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Grounded Test
		RaycastHit2D hit = Physics2D.Raycast (new Vector2(transform.position.x, transform.position.y), Vector2.down, 1f);
		isGrounded = hit.collider != null;
		Debug.Log (isGrounded);

		// Move
		Vector2 velo = Vector2.zero;
		velo.y = rb.velocity.y;

		if (InputController.isButtonDown (GameButton.LEFT)) {
			velo.x = speed * -1;
		}
		if (InputController.isButtonDown (GameButton.RIGHT)) {
			velo.x = speed;
		}
		rb.velocity = velo;
		if (InputController.isButtonJustDown (GameButton.JUMP) && isGrounded) {
			rb.AddForce(Vector2.up * jumpForce);
		}


	}
}
