using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour {

	public GameObject spider;
	public GameObject levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find ("LevelManager");
		LevelManagerScript levelControl = levelManager.GetComponent<LevelManagerScript> ();
		levelControl.numOfSpawners += 1;
		float chance = levelControl.spawnChance ();
		float roll = Random.Range (0f, 100f);
		if (roll < chance) {
			Instantiate (spider, new Vector3 (this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
		}
	}
}
