using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Spider") {
			coll.gameObject.GetComponent<SpiderControl> ().ChangeDirection();
		}
		print ("FUCK YOU");
	}
}
