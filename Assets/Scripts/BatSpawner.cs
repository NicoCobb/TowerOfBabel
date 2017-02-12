using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour {

	public GameObject bat;
	public GameObject levelManager;

	// Use this for initializationvoid Start () {
	void Start(){
		Spawn ();
	}
	void Spawn () {
		levelManager = GameObject.Find ("LevelManager");
		LevelManagerScript levelControl = levelManager.GetComponent<LevelManagerScript> ();
		levelControl.numOfSpawners += 1;
		float chance = levelControl.spawnChance ();
		float roll = Random.Range (0f, 100f);
		if (roll < chance) {
			Instantiate (bat, new Vector3 (this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
			levelControl.numOfSpawners += 1;
		}
	}
}
