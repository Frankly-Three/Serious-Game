using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Place : MonoBehaviour {

	public int tokens;
	private List<Orbital> orbitals = new List<Orbital>();
	private Platform listener;

	void Start () {
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
	}

	public void RegisterPlatform(Platform obj){
		listener = obj;
	}
}
