using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManagerScript : MonoBehaviour {

	[HideInInspector]
	public int[] levels;
	[HideInInspector]
	public int numOfSpawners = 0;
	public int numberOfLevels = 2;
	public int totalLevels = 1;
	public int levelChosen;
	public GameObject Level1;
	public GameObject Level2;
	public GameObject[] Spiders;
	public GameObject[] Bats;
	public GameObject[] Players;
	public GameObject player;
	public GameObject[] DoorStarts;
	public GameObject doorStart;

	// Use this for initialization
	void Start () {
		levels = new int[numberOfLevels];
		for (int i = 0; i < numberOfLevels; i++) {
			levels [i] = i + 1;
		}
		int randomInt = Random.Range (0, numberOfLevels);
		print (randomInt);
		levelChosen = levels [randomInt];
		createLevel();
	}

	void FixedUpdate () {
		Players = GameObject.FindGameObjectsWithTag ("Player");
		DoorStarts = GameObject.FindGameObjectsWithTag ("DoorStart");

		if (Players.Length < 1 && DoorStarts.Length > 0) {
			doorStart = GameObject.FindGameObjectWithTag ("DoorStart");
			Instantiate (player, doorStart.transform.position, Quaternion.identity);
			player = GameObject.FindGameObjectWithTag ("Player");
		}
	}

	void createLevel() {
		if (levelChosen == 1) {
			Instantiate (Level1, new Vector3 (0, 0, 0), Quaternion.identity);
		}
		if (levelChosen == 2) {
			Instantiate (Level2, new Vector3 (0, 0, 0), Quaternion.identity);
		}
	}

	public void endLevel(){
		Spiders = GameObject.FindGameObjectsWithTag ("Spider");
		Bats = GameObject.FindGameObjectsWithTag ("Bat");

		for(int i = 0; i < Spiders.Length; i ++){
			Destroy(Spiders[i]);
		}
		for(int i = 0; i < Bats.Length; i ++){
			Destroy(Bats[i]);
		}
		if (levelChosen == 1) {
			Destroy(Level1);
		}
		if (levelChosen == 2) {
			Destroy (Level2);
		}
		int currentLevel = levelChosen;
		while (levelChosen == currentLevel){
			int randomInt = Random.Range (0, numberOfLevels);
			print (randomInt);
			levelChosen = levels [randomInt];
		}
		createLevel();
		player.transform.position = doorStart.transform.position;
	}

	public float spawnChance(){
		if (numOfSpawners == 0)
			return 100f;
		return 100f * 1.8f / ((numOfSpawners * 1.0f) + 1f) + .1f * (numberOfLevels * 1.0f);
	}
}
