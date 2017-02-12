using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBrick : MonoBehaviour {

	//	private Rigidbody2D brick;
	//	private BoxCollider2D coll;

	// Use this for initialization
	void Start () {
		//		brick = this.GetComponent<Rigidbody2D> ();
		//		coll = this.GetComponent<BoxCollider2D> ();
		Destroy(gameObject, 1f);
	}

	// Update is called once per frame
	void Update () {
		//		if (brick != null && brick.velocity == new Vector2 (0, 0)) {
		//			Destroy ();
		//		}
	}
}