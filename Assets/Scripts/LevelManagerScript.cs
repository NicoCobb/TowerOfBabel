using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManagerScript : MonoBehaviour {

	[HideInInspector]
	public int[] levels;
	public int numberOfLevels = 4;
	public int totalLevels = 1;

	// Use this for initialization
	void Start () {
		levels = new int[numberOfLevels];
		for (int i = 0; i < numberOfLevels; i++) {
			levels [i] = i + 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
