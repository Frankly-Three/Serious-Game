using UnityEngine;
using System.Collections;

public class ConstantForceEqualtToGravity : MonoBehaviour {

	// Use this for initialization
	void Start() {
	
	}

	void FixedUpdate() {
		gameObject.rigidbody.AddRelativeForce(Physics.gravity * gameObject.rigidbody.mass);
	}
}
