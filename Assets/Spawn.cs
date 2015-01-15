using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	public AudioClip respawnSound;
	public AudioClip suicideSound;
	public List<GameObject> spawns = new List<GameObject>();
	private GameObject spot;
	private int size;
	private int index;
	private int offset;
	private int lastRespawnIndex;
	private float interval = 1.0f;
    private float timeLeft = -0.1f;
	private bool isSuiciding;
	
	void Awake () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		spot = player.transform.FindChild("Spotlight").gameObject;
		
		transform.position = new Vector3(
			spawns[0].transform.position.x - 0.1f,
			spawns[0].transform.position.y,
			spawns[0].transform.position.z
		);
		size = spawns.Count;
		index = -1;
		offset = 0;
		lastRespawnIndex = 0;
		isSuiciding = false;
	}
	
	void Update () {
		if(index == size - 1){
			GameObject.FindGameObjectWithTag ("Player").GetComponent<EscScript>().SetWon();
		}else{
			GameObject spawn = spawns[index + 1];
			if (Vector3.Distance(transform.position, spawn.transform.position) <= 2.0f) {
			//if(transform.position.x > spawn.transform.position.x){
				//reached checkpoint
				spawn.GetComponent<ParticleSystem>().startColor =  new Color(1.0f, 0.5f, 0.05f);
				timeLeft = interval;
				index++;
				offset = 0;
			}
			GameObject resetSpawn = spawns[lastRespawnIndex + 1];
			if(transform.position.x > resetSpawn.transform.position.x){
				//reached checkpoint again
				offset = 0;
			}
			if(transform.position.y < -10.0f || Input.GetKeyDown(KeyCode.R)) {
				//reset
				ResetPetrinets();
				if (index + offset < 0) {
					offset = -index;
				}
				if (transform.position.y < -10.0f) {
					if (!isSuiciding) {
						audio.PlayOneShot(suicideSound);
					}
					isSuiciding = true;
					offset = 0;
				}
				Respawn(index + offset);
				if (Input.GetKeyDown(KeyCode.R)) {
					offset--;
				}
			}
		}
		if(timeLeft < 0.0f){
			timeLeft = 0.0f;
			spot.GetComponent<Light>().color = Color.white;
		}else if (timeLeft > 0.0f){
			timeLeft -= Time.deltaTime;
			float i = (timeLeft * 2 * Mathf.PI) / interval;
			float angle = 32.0f + (20.0f * Mathf.Cos(i));
			float intensity = 2.2f + (1.0f * Mathf.Cos(i));
			spot.GetComponent<Light>().spotAngle = angle;
			spot.GetComponent<Light>().intensity = intensity;
			spot.GetComponent<Light>().color = new Color(intensity - 2.2f, 1.0f, intensity - 2.2f);
		}
	}
	
	private void Respawn(int i){
		audio.PlayOneShot(respawnSound);
		transform.position = spawns[i].transform.position;
		lastRespawnIndex = i;
		isSuiciding = false;
	}

	public void DoRespawn() {
		if (!isSuiciding) {
			audio.PlayOneShot(suicideSound);
		}
		isSuiciding = true;
		Respawn(index);
	}

	public bool getIsSuiciding() {
		return isSuiciding;
	}

	private void ResetPetrinets() {
		GameObject[] places = GameObject.FindGameObjectsWithTag("Place");
		foreach (GameObject place in places) {
			if (place.transform.position.x >= spawns[Mathf.Max(lastRespawnIndex - 1, 0)].transform.position.x 
			    && place.transform.position.x <= spawns[Mathf.Min(lastRespawnIndex + 1, size - 1)].transform.position.x) {
				Place placeScript = place.GetComponent<Place>();
				placeScript.Reset();
			}
		}
	}
}
