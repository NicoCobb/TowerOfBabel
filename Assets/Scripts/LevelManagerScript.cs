using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManagerScript : MonoBehaviour {

	[HideInInspector]
	public int[] levels;
	public int totalLevels = 1;

	// Use this for initialization
	void Start () {
		levels = new int[1,2,3,4];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
