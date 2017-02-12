using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : MonoBehaviour {

	public float distToPlayer = 6f;
	public float swoopTime = 3f;

	private GameObject Player;
	private Vector3 StartingPos;
	private Vector3 FoundPlayerPos;
	private bool Swoop = false;
	private bool HeadHome = false;

	// Use this for initialization
	void Start () {
		StartingPos = transform.position;
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		Vector3 PlayerPos = Player.transform.position;
		if (Vector3.Distance (StartingPos, PlayerPos) < distToPlayer && StartingPos.y > PlayerPos.y && !Swoop && !HeadHome) {
			Swoop = true;
			FoundPlayerPos = PlayerPos;
		} else if (Swoop && !HeadHome) {
			GoTo (FoundPlayerPos);
			Swoop = false;
			HeadHome = true;
		} else if (!Swoop && HeadHome && transform.position == FoundPlayerPos) {
			GoTo (StartingPos);
			Swoop = true;
			HeadHome = true;
		} else if (Swoop && HeadHome && transform.position == StartingPos) {
			Swoop = false;
			HeadHome = false;
		}
	}

	void GoTo(Vector3 OtherPos) {
		transform.position = Vector3.Lerp (transform.position, OtherPos, Time.deltaTime);
	}
}
