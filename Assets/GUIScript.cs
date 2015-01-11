using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	public GUISkin h1skin;
	public GUISkin h2skin;
	public GUISkin h3skin_active;
	public GUISkin h3skin_inactive;

	void OnGUI() {
		int widthOffset = 100;
		int heightOffset = 100;

		int width = Screen.width - (2 * widthOffset);
		int height = Screen.height - (2 * heightOffset);
		GUI.Box(new Rect(widthOffset, heightOffset, width, height), "");

		GUI.skin = h1skin;
		GUI.Label(rectFromMiddle(325, 550, heightOffset + 100, 75), "Geeks in Space");

		GUI.skin = h2skin;
		GUI.Button(rectFromMiddle(400, heightOffset + 200, 50), "Play");
		GUI.skin = h3skin_inactive;
		GUI.enabled = false;
		GUI.Button(rectFromMiddle(350, heightOffset + 250, 35), "Level 1");
		GUI.Button(rectFromMiddle(350, heightOffset + 285, 35), "Level 2");
		GUI.skin = h3skin_active;
		GUI.enabled = true;
		if (GUI.Button(rectFromMiddle(350, heightOffset + 320, 35), "Level 3")) {
			Application.LoadLevel("MainLevel2");
		}

		GUI.skin = h2skin;
		if (GUI.Button(rectFromMiddle(400, heightOffset + 355, 50), "Wiki")) {
			Application.OpenURL("http://en.wikipedia.org/wiki/Petri_net");
		}
		if (GUI.Button(rectFromMiddle(400, heightOffset + 405, 50), "Exit")) {
			UnityEditor.EditorApplication.isPlaying = false;
			Application.Quit();
		}
	}

	private Rect rectFromMiddle(int width, int heightOffset, int height) {
		int offsetFromMiddle = width / 2;
		int middleX = Screen.width / 2;
		return new Rect(middleX - offsetFromMiddle, heightOffset, offsetFromMiddle * 2, height);
	}
	
	private Rect rectFromMiddle(int width, int width2, int heightOffset, int height) {
		int offsetFromMiddle = width / 2;
		int middleX = Screen.width / 2;
		return new Rect(middleX - offsetFromMiddle, heightOffset, offsetFromMiddle + (width2 / 2), height);
	}
}
