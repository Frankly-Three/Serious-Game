using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public Place place;
	public Vector3 direction;
	private Vector3 origin;
	public int magnitude;

	// Use this for initialization
	void Start () {
		origin = transform.position;
		place.RegisterPlatform(this);
		transform.position = origin + place.tokens * direction * magnitude;
	}

	public void Move(){
		transform.position = origin + place.tokens * direction * magnitude;
	}
}
