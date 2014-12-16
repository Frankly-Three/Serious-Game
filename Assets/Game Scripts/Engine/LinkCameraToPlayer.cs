using UnityEngine;
using System.Collections;

public class LinkCameraToPlayer : MonoBehaviour {
	public bool linkX;
	public bool linkY;
	public bool linkZ;
	
	private GameObject player;
	
	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = (linkX) ? player.transform.position.x : gameObject.transform.position.x;
		float y = (linkY) ? player.transform.position.y : gameObject.transform.position.y;
		float z = (linkZ) ? player.transform.position.z : gameObject.transform.position.z;
		gameObject.camera.transform.position = new Vector3(x, y, z);
	}
}
