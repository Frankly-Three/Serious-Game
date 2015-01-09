using UnityEngine;
using System.Collections;

public class Planet_Turning : MonoBehaviour {

	public int rotateFactor = 20;
	public int radius;
	public GameObject rAround;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(rAround.transform.localPosition , Vector3.up, rotateFactor * Time.deltaTime);
	}
}
