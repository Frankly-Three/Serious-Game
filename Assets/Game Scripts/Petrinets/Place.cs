using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Place : MonoBehaviour {

	public int tokens;
	private int initialTokens;
	private List<Orbital> orbitals = new List<Orbital>();
	private Platform listener;
	private Texture2D occupied;
	private Texture2D empty;

	void Awake() {
		this.initialTokens = tokens;
	}

	void Start () {
		occupied = Resources.Load<Texture2D>("place_occupied");
	    empty = Resources.Load <Texture2D>("place_empty");
		UpdateOrbitals(false);
	}
	
	void Update () {
		foreach(Orbital orb in orbitals){
			orb.Update();
		}
	}

	public void UpdateOrbitals(bool playSound) {
		int diff = orbitals.Count - tokens;
		if(diff > 0){
			while(diff > 0){
				if(orbitals.Count > 0){
					Orbital orb = orbitals[orbitals.Count - 1];
					orbitals.Remove(orb);
					Destroy(orb.GetOrb());
				}
				diff--;
			}
		}else{
			while(diff < 0){
				Orbital orb = new Orbital(this, orbitals.Count);
				orbitals.Add(orb);
				diff++;
			}
		}
		if(listener!=null){
			listener.Move(playSound);
		}
		if (tokens > 0) {
			renderer.material.mainTexture = occupied;
		} else {
			renderer.material.mainTexture = empty;
		}
	}

	public void RegisterPlatform(Platform obj){
		listener = obj;
	}

	public void Reset() {
		tokens = initialTokens;
		UpdateOrbitals(false);
	}
}
