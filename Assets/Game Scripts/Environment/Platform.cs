using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public Place place;
	public Vector3 direction;
	private Vector3 origin;

	// Use this for initialization
	void Start () {
		origin = transform.position;
		place.RegisterPlatform(this);
	}

	public void Move(){
		transform.position = origin + place.tokens * direction;
	}
}
