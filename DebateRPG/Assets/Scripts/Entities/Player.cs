﻿using UnityEngine;
using System.Collections;

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

	private BoxCollider2D groundDetector;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponentInChildren<SpriteRenderer> ();
		groundDetector = GetComponentInChildren<BoxCollider2D> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Grounded Test
		isGrounded = groundDetector.IsTouchingLayers();


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
		switch (c.tag) {
		case "Enemy":
			print ("Start Fight");
			break;

		}
	}


	
}
