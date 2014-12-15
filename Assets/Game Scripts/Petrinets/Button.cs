using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public float topLimit;
	public float bottomLimit;

	private GameObject player;
	private Vector3 startPosition;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Use this for initialization
	void Start () {
		startPosition = gameObject.transform.position;
	}

	void OnCollisionEnter(Collider other) {
		if (other.Equals(player)) {
			gameObject.GetComponentInParent<Transition>().execute();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 translation = gameObject.transform.position - startPosition;
		if (translation.y > topLimit) {
			gameObject.transform.Translate(0f, -Mathf.Abs(topLimit - translation.y), 0f);
		}
		if (translation.y < bottomLimit) {
			gameObject.transform.Translate(0f, Mathf.Abs(translation.y - bottomLimit), 0f);
		}
	}
}
