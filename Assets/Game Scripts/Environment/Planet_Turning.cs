using UnityEngine;
using System.Collections;

public class Planet_Turning : MonoBehaviour {

	public int rotateFactor = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(Vector3.zero, Vector3.up, rotateFactor * Time.deltaTime);
	}
}
