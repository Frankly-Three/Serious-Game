using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	
	private GameObject player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		spawnPlayer();
	}

	public void spawnPlayer () {
		player.transform.position = transform.position;
		this.enabled = false;
	}
}
