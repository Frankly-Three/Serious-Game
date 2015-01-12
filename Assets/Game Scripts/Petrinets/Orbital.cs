using UnityEngine;
using System.Collections;

public class Orbital {

	private GameObject obj;
	private Vector3 up;
	private Place place;
	private float rotateFactor;

	public Orbital (Place p, int distance) {
		place = p;
		rotateFactor = Random.Range(100.0f, 150.0f);
		obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		obj.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
		float dist = 0.65f * place.transform.localScale.x + 0.075f * distance;
		obj.transform.position = place.transform.position + new Vector3(dist, 0.0f, 0.0f);
        up = new Vector3(0.0f, 0.0f, 1.0f);
		obj.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.25f, 0.9f), Random.Range(0.25f, 0.9f), Random.Range(0.25f, 0.9f));
	}
	
	public void Update () {
		obj.transform.RotateAround(place.transform.position, up, rotateFactor * Time.deltaTime);
	}
	
	public GameObject GetOrb(){
		return obj;
	}
}
