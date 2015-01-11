using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {

	public int tokens;
	private int initialTokens;
	private TextMesh label;
	private Platform listener;
	private Texture2D occupied;
	private Texture2D empty;

	void Awake() {
		this.initialTokens = tokens;
	}

	void Start () {
		occupied = Resources.Load<Texture2D>("place_occupied");
	    empty = Resources.Load <Texture2D>("place_empty");
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
		UpdateLabel(false);
	}
}
