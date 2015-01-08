using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Transition : MonoBehaviour {
	
	public List<Place> inPlace = new List<Place>();
	public Dictionary<Place, GameObject> pointers = new Dictionary<Place, GameObject>();
	public List<Place> outPlace = new List<Place>();

	private GameObject player;
	private GameObject transition;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start(){
		foreach (Place place in inPlace) {
			GameObject pointer = (GameObject)Instantiate(Resources.Load("PetriPointer"));
			pointer.particleSystem.startColor = Color.yellow;

			pointer.transform.position = place.transform.position;
			Vector3 relativePos = transform.position - place.transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);
			pointer.transform.rotation = rotation;
			pointers.Add(place, pointer);
		}
		foreach (Place place in outPlace) {
			GameObject pointer = (GameObject)Instantiate(Resources.Load("PetriPointer"));
			pointer.particleSystem.startColor = Color.green;

			pointer.transform.position = transform.position;
			Vector3 relativePos = place.transform.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);
			pointer.transform.rotation = rotation;
			pointers.Add(place, pointer);
		}
	}

	void OnMouseDown() {
		Execute();
	}

	private void Execute(){
		bool canExectute = true;
		//Check
		foreach (Place place in inPlace) {
			if(place.tokens == 0){
				//Not all input places have tokens available
				canExectute = false;
				pointers[place].particleSystem.startColor = Color.red;
				pointers[place].particleSystem.emissionRate = 10;
			}
		}
		if(!canExectute){
			Invoke("reset", 0.3f);
			return;
		}
		//Check passed
		//In
		foreach (Place place in inPlace) {
			place.tokens--;
			place.UpdateLabel();

			pointers[place].particleSystem.startColor = Color.blue;
			pointers[place].particleSystem.emissionRate = 10;
		}
		//Out
		foreach (Place place in outPlace) {
			place.tokens++;
			place.UpdateLabel();

			pointers[place].particleSystem.startColor = Color.blue;
			pointers[place].particleSystem.emissionRate = 10;

		}
		//Reset animation
		Invoke("reset", 0.3f);
	}

	public void reset(){
		foreach (Place place in inPlace) {
			pointers[place].particleSystem.startColor = Color.yellow;
			pointers[place].particleSystem.emissionRate = 4;
		}
		foreach (Place place in outPlace) {
			pointers[place].particleSystem.startColor = Color.green;
			pointers[place].particleSystem.emissionRate = 4;
			
		}
	}
}
