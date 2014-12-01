using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	
	public GameObject player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		spawnPlayer ();
	}

	void spawnPlayer () {
		player.transform.position = transform.position;
		this.enabled = false;
	}
}
