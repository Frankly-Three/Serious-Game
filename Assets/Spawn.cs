using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	public List<GameObject> spawns = new List<GameObject>();
	private GameObject spot;
	private int size;
	private int index;
	private float interval = 1.0f;
    private float timeLeft = -0.1f;
	
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
	}
	
	void Update () {
		if(index == size - 1){
			Debug.Log("WON!!!");
		}else{
			GameObject spawn = (GameObject)(spawns[index + 1]);
			if(transform.position.x > spawn.transform.position.x){
				spawn.GetComponent<ParticleSystem>().startColor =  new Color(1.0f, 0.5f, 0.05f);
				timeLeft = interval;
				index++;
			}
			if(transform.position.y < -10.0f){
				Respawn();
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
	
	private void Respawn(){
		transform.position = spawns[index].transform.position;
	}
}
