using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {

	public int tokens;
	private TextMesh label;
	private Platform listener;

	void Start () {
		label = GetComponentInChildren<TextMesh>();
		//label.transform.position = transform.position;
		label.transform.position = new Vector3 (
			transform.position.x,
			transform.position.y,
			transform.position.z - 0.3f
			);
		//label.transform.position.z = transform.position.z - 2;
		//label.color = Color.black;
		//label.fontSize = 32;
		UpdateLabel(false);
	}

	public void UpdateLabel(bool playSound) {
		label.GetComponent<TextMesh>().text = tokens.ToString();
		if(listener!=null){
			listener.Move(playSound);
		}
		if (tokens > 0) {
			Texture texture = Resources.Load ("place_occupied") as Texture;
			if (texture) {
				renderer.material.mainTexture = texture;
			}
		} else {
			Texture texture = Resources.Load ("place_empty") as Texture;
			if (texture) {
				renderer.material.mainTexture = texture;
			}
		}
	}

	public void RegisterPlatform(Platform obj){
		listener = obj;
	}
}
