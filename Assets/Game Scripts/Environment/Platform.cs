using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	public AudioClip moveSound;
	public Place place;
	public Vector3 direction;
	private Vector3 origin;
	public int magnitude;

	private Vector3 targetPosition;
	private Vector3 velocity = Vector3.zero;
	private float dampTime = 0.2f;

	void Awake() {
		targetPosition = transform.position;
		origin = transform.position;
		if (place.tokens > 0) { // only apply when place already contains tokens
		    targetPosition = origin + place.tokens * direction * magnitude;
		}
		place.RegisterPlatform(this);
	}

	// Use this for initialization
	void Start () {

	}

	public void Move(bool playSound){
		//transform.position = origin + place.tokens * direction * magnitude;
		targetPosition = origin + place.tokens * direction * magnitude;
		if (playSound) {
			audio.PlayOneShot(moveSound);
		}
	}

	void Update() {
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, dampTime);
	}
}
