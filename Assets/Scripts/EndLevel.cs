using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

	public GameObject levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find ("LevelManager");
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			LevelManagerScript levelControl = levelManager.GetComponent<LevelManagerScript> ();
			levelControl.endLevel ();
		}
	}
}
