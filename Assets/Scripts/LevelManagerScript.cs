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
	public GameObject[] Spiders;
	public GameObject Player;
	public GameObject DoorStart;

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

	void createLevel() {
		if (levelChosen == 1) {
			Instantiate (Level1, new Vector3 (0, 0, 0), Quaternion.identity);
		}
		Player = GameObject.FindGameObjectWithTag ("Player");
		DoorStart = GameObject.FindGameObjectWithTag ("DoorStart");
		Player.transform.position = new Vector3(DoorStart.transform.position.x,DoorStart.transform.position.y,DoorStart.transform.position.z-1);
	}

	public void endLevel(){
		totalLevels++;
		Spiders = GameObject.FindGameObjectsWithTag ("Spider");

		for(int i = 0; i < Spiders.Length; i ++){
			Destroy(Spiders[i]);
		}

		Player = GameObject.FindGameObjectWithTag ("Player");
		DoorStart = GameObject.FindGameObjectWithTag ("DoorStart");
		Player.transform.position = new Vector3(DoorStart.transform.position.x,DoorStart.transform.position.y,DoorStart.transform.position.z-1);

		numOfSpawners = 0;
		Spiders = GameObject.FindGameObjectsWithTag ("SpiderSpawner");
		for(int i = 0; i < Spiders.Length; i ++){
			SpiderSpawner spiderSpawnControl = Spiders[i].GetComponent<SpiderSpawner> ();
			spiderSpawnControl.Spawn();
		}
	}

	public float spawnChance(){
		if (numOfSpawners == 0)
			return 100f;
		return 100f * 1.8f / ((numOfSpawners * 1.0f) + 1f) + .1f * (numberOfLevels * 1.0f);
	}
}
