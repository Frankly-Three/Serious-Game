using UnityEngine;
using System.Collections;

public class CutOff : MonoBehaviour {

	private GameObject player;
	private GameObject spot;
	private GameObject camera;
	private float interval = 1.0f;
    private float timeLeft = -0.1f;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		spot = player.transform.FindChild("Spotlight").gameObject;
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update(){
		if(player.transform.position.x < transform.position.x){
			player.transform.position = new Vector3(
				transform.position.x,
				player.transform.position.y,
				player.transform.position.z
			);
			transform.position = new Vector3(
				transform.position.x,
				player.transform.position.y,
				transform.position.z
			);
			if(timeLeft == 0.0f){
				timeLeft = interval;
			}
			particleSystem.Emit(5);
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
			spot.GetComponent<Light>().color = new Color(1.0f, intensity - 2.2f, intensity - 2.2f);
		}
	}
}
