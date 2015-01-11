using UnityEngine;
using System.Collections;

public class Planet_Turning : MonoBehaviour {

	public int rotateFactor = 20;
	public Vector3 rotateVector = Vector3.up;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(Vector3.zero, rotateVector, rotateFactor * Time.deltaTime);
	}
}
