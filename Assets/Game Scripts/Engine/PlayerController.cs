using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float sidewaysModifier;
	public float jumpingModifier;
	public float raycastMargin;

	private GameObject spawn;

	void Awake() {
		spawn = GameObject.FindGameObjectWithTag("Spawn");
	}

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			spawn.GetComponent<SpawnPoint>().spawnPlayer();
		}

		if (!IsGrounded()) {
			return;
		}
		//can only move left/right and jump when on the ground
		if (Input.GetKey(KeyCode.RightArrow)) {
			gameObject.rigidbody.AddForce(Vector3.right * sidewaysModifier);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			gameObject.rigidbody.AddForce(Vector3.left * sidewaysModifier);
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			gameObject.rigidbody.AddForce(Vector3.up * jumpingModifier);
		}
	}

	bool IsGrounded() {
		return Physics.Raycast(gameObject.transform.position, -Vector3.up, collider.bounds.extents.y + raycastMargin);
	}
}
