using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderControl : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the enemy is currently facing.

	public float moveForce = 365f;			// Amount of force added to move the enemy left and right.
	public float maxSpeed = 5f;				// The fastest the enemy can travel in the x axis.

	private Transform groundCheck;			// A position marking where to check if the enemy is grounded.
	private bool grounded = false;			// Whether or not the enemy is grounded.
	private Animator anim;					// Reference to the enemy's animator component.

	// Use this for initialization
	void Start () 
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
	}

	void Update ()
	{

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(h));

		// If the enemy is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			// ... add a force to the enemy.
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

		// If the enemy's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the enemy's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		// If the input is moving the enemy right and the enemy is facing left...
		if(h > 0 && !facingRight)
			// ... flip the enemy.
			Flip();
		// Otherwise if the input is moving the enemy left and the enemy is facing right...
		else if(h < 0 && facingRight)
			// ... flip the enemy.
			Flip();
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
