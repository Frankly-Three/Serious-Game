using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public GameObject player;

	public void ButtonClickTest() {
		player.transform.localScale += new Vector3(2f, 2f, 0);
	}

	
}
