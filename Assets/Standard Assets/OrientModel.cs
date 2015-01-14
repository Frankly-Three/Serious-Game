using UnityEngine;
using System.Collections;

public class OrientModel : MonoBehaviour {
	
	private bool dirRight;
	
	private GameObject model;
	private GameObject player;
	
	void Awake(){
		model = GameObject.FindGameObjectWithTag ("AnimModel");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start () {
		dirRight = true;
	}

	void Update () {
		model.transform.rotation = Quaternion.Slerp(
			model.transform.rotation,
			Quaternion.Euler(0, dirRight?90:270, 0),
			Time.deltaTime * 10f
		);
		model.transform.position = new Vector3(
			player.transform.position.x,
			player.transform.position.y - 1.025f,
			player.transform.position.z
		);
	}

	public void SetDirection(bool right){
		dirRight = right;
	}
}
