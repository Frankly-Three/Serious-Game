using UnityEngine;
using System.Collections;

public class EscScript : MonoBehaviour {
	public GUISkin skin;

	private bool _isPaused;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
			if (_isPaused) {
				stopPause();
			}
			else {
				pause();
			}
		}
	}

	void OnGUI() {
		if (_isPaused) {
			GUI.skin = skin;

			int widthOffset = 100;
			int heightOffset = 100;
			
			int width = Screen.width - (2 * widthOffset);
			int height = Screen.height - (2 * heightOffset);
			GUI.Box(new Rect(widthOffset, heightOffset, width, height), "");

		    int middleHeight = Screen.height / 2;
			if (GUI.Button(rectFromMiddle(400, middleHeight - 75, 50), "Continue Level")) {
				stopPause();
			}
			if (GUI.Button(rectFromMiddle(400, middleHeight - 25, 50), "Restart Level")) {
				Application.LoadLevel(Application.loadedLevel);
				stopPause();
			}
			if (GUI.Button(rectFromMiddle(400, middleHeight + 25, 50), "Exit Level")) {
				Application.LoadLevel("Menu");
				stopPause();
			}
		}
	}

	private void pause() {
		_isPaused = true;
		Time.timeScale = 0.0f;
	}

	private void stopPause() {
		_isPaused = false;
		Time.timeScale = 1.0f;
	}

	private Rect rectFromMiddle(int width, int heightOffset, int height) {
		int offsetFromMiddle = width / 2;
		int middleX = Screen.width / 2;
		return new Rect(middleX - offsetFromMiddle, heightOffset, offsetFromMiddle * 2, height);
	}

	public bool isPaused() {
		return _isPaused;
	}
}
