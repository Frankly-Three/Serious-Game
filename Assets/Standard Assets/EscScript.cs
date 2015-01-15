using UnityEngine;
using System.Collections;

public class EscScript : MonoBehaviour {
	public GUISkin skin;

	private bool _isPaused;

	private string timerLabelText = "00:00";
	private float startTime;

	private bool won;

	void Awake() {
		startTime = Time.time;
	}

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
		int elapsedTime = (int)(Time.time - startTime);

		int minutes = (elapsedTime / 60);
		int seconds = elapsedTime - (minutes * 60);

		timerLabelText = addLeadingZero(minutes.ToString()) + ":" + addLeadingZero(seconds.ToString());
	}

	private string addLeadingZero(string value) {
		if (value.Length == 1) {
			return "0" + value;
		}
		return value;
	}

	void OnGUI() {
		GUISkin oldSkin = GUI.skin;
		GUI.skin = skin;
		if (_isPaused) {

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
		else if (won) {
			int widthOffset = 100;
			int heightOffset = 100;
			
			int width = Screen.width - (2 * widthOffset);
			int height = Screen.height - (2 * heightOffset);
			GUI.Box(new Rect(widthOffset, heightOffset, width, height), "");
			
			int middleHeight = Screen.height / 2;
			GUI.Label(rectFromMiddle(400, middleHeight - 125, 50), "You won!");
			if (GUI.Button(rectFromMiddle(400, middleHeight - 25, 50), "Restart Level")) {
				Application.LoadLevel(Application.loadedLevel);
				stopPause();
			}
			if (GUI.Button(rectFromMiddle(400, middleHeight + 25, 50), "Exit Level")) {
				Application.LoadLevel("Menu");
				stopPause();
			}
		}

		GUI.Label(rectFromMiddle(200, 100, 50), timerLabelText);
		GUI.skin = oldSkin;
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

	public void SetWon() {
		won = true;
		Invoke("timezero", 0.1f);
	}

	public bool GetWon() {
		return won;
	}

	private void timezero() {
		Time.timeScale = 0.0f;
	}
}
