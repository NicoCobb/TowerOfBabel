using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

	public GameObject levelManager;
	public GameObject player;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find ("LevelManager");
		player = GameObject.Find ("Player");
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			player.transform.position = new Vector3(0,0,0);
			LevelManagerScript levelControl = levelManager.GetComponent<LevelManagerScript> ();
			levelControl.endLevel ();
		}
	}
}
