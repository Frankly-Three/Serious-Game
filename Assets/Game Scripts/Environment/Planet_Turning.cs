
using UnityEngine;
using System.Collections;

public class Planet_Turning : MonoBehaviour {

	public int rotateFactor = 20;
	public Vector3 rotateVector = Vector3.up;
	public Vector3 rotation;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetUpdateOrigin = (target == null) ? Vector3.zero : target.transform.position;
		Vector3 targetUpdateRotation = (target == null) ? Vector3.up : rotation;
		transform.RotateAround(targetUpdateOrigin, targetUpdateRotation, rotateFactor * Time.deltaTime);
	}
}
