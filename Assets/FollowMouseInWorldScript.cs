using UnityEngine;
using System.Collections;

public class FollowMouseInWorldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 10f;
		transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		Debug.Log(transform.position);
	}
}
