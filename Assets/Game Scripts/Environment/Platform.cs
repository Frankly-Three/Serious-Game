using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	public AudioClip moveSound;
	public Place place;
	public Vector3 direction;
	private Vector3 origin;
	public int magnitude;

	// Use this for initialization
	void Start () {
		origin = transform.position;
		place.RegisterPlatform(this);
	}

	public void Move(bool playSound){
		transform.position = origin + place.tokens * direction * magnitude;
		if (playSound) {
			audio.PlayOneShot(moveSound);
		}
	}
}
