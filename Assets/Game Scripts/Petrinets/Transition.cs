using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Transition : MonoBehaviour {
	
	public List<Place> inPlace = new List<Place>();
	public List<Place> outPlace = new List<Place>();

	private GameObject button;
	private GameObject transition;

	void Awake(){
		button = gameObject.GetComponentsInChildren<Transform>()[0].gameObject;
	}

	void OnTriggerEnter(Collider other) {
//		if(!other.gameObject.Equals(button)){
//			gameObject.
//		}
	}

	public void execute(){
		//Check
		foreach (Place place in inPlace) {
			if(place.tokens == 0){
				//Not all input places have tokens available
				//TODO: Fire rejection animation between place and this
				return;
			}
		}
		//Check passed
		//TODO: Fire execute animations
		//In
		foreach (Place place in inPlace) {
			place.tokens--;
			place.UpdateLabel();
		}
		//Out
		foreach (Place place in outPlace) {
			place.tokens++;
			place.UpdateLabel();
		}
	}
}
