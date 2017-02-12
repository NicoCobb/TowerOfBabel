using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBrick : MonoBehaviour {

	public Rigidbody2D brick;
	public GameObject player;
	public GameObject brickSpawn;
	public float brickForce = 10f;
	bool hasBrickBool;
	PlayerControl playerControl;

	void Start() {
		player = GameObject.Find ("Player");
		brickSpawn = GameObject.Find ("BrickSpawn");
		playerControl = player.GetComponent<PlayerControl> ();
		hasBrickBool = playerControl.hasBrick;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Space) && playerControl.hasBrick) {
			Rigidbody2D brickInstance;
			brickInstance = Instantiate (brick, brickSpawn.transform.position, Quaternion.identity) as Rigidbody2D;
			if (!playerControl.facingRight) {
				brickInstance.AddForce (new Vector2(500, 0));
			} else if (playerControl.facingRight) {
				brickInstance.AddForce (new Vector2(-500, 0));
			}

			hasBrickBool = false;
		}
	}
}