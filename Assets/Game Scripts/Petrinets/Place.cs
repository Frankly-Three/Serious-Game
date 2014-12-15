using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {

	public int tokens;
	private TextMesh label;

	void Start () {
		label = GetComponentInChildren<TextMesh>();
		label.transform.position = transform.position;
		label.color = Color.black;
		label.fontSize = 48;
		UpdateLabel();
	}

	public void UpdateLabel () {
		label.GetComponent<TextMesh>().text = tokens.ToString();
	}
}
