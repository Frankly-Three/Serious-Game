using UnityEngine;
using System.Collections;

public class CutOff : MonoBehaviour {

	public GameObject player;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		if(player.transform.position.x < transform.position.x){
			player.transform.position = new Vector3(
				transform.position.x,
				player.transform.position.y,
				player.transform.position.z
			);
		}
	}
}
