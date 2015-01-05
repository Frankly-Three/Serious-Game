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
		UpdateLabel();
	}

	public void UpdateLabel () {
		label.GetComponent<TextMesh>().text = tokens.ToString();
		if(listener!=null){
			listener.Move();
		}
	}

	public void RegisterPlatform(Platform obj){
		listener = obj;
	}
}
