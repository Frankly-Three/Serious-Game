using UnityEngine;
using System.Collections;

public class Planet_Turning : MonoBehaviour {

	public int rotateFactor = 20;
	public Vector3 rotation;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(target.transform.localPosition, rotation, rotateFactor * Time.deltaTime);
	}
}
