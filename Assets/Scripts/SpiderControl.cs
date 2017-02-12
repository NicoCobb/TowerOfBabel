using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderControl : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the enemy is currently facing.
	public float moveForce = 365f;			// Amount of force added to move the enemy left and right.
	public float speed = 6f;

	private Animator anim;					// Reference to the enemy's animator component.

	// Use this for initialization
	void Start () 
	{
		// Setting up references.
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
		anim = GetComponent<Animator>();
	}

	void Update ()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D> ().velocity.x) * speed, GetComponent<Rigidbody2D> ().velocity.y);
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		// If the input is moving the enemy right and the enemy is facing left...
		if(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) > 0 && !facingRight)
			// ... flip the enemy.
			Flip();
		// Otherwise if the input is moving the enemy left and the enemy is facing right...
		else if(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) < 0 && facingRight)
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

	public void ChangeDirection()
	{
		//Changes direction, duh
		GetComponent<Rigidbody2D> ().velocity = new Vector2(-GetComponent<Rigidbody2D> ().velocity.x, GetComponent<Rigidbody2D> ().velocity.y);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			SceneManager.LoadScene (1);
		}
	}
}
