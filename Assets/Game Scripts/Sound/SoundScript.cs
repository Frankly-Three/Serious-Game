using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	public float walkingVelocityMargin = 0.05f;

	public AudioClip jumpSound;
	public AudioClip touchDownSound;
	public AudioClip walkSound;

	private GameObject player;
	private bool isPlayerJumping;

	private Vector3 lastPlayerPosition;

	// Use this for initialization
	void Start () {
	
	}

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		lastPlayerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//jumping and touchdown sounds
		if (isPlayerJumping && IsPlayerGrounded()) {
			player.audio.PlayOneShot(touchDownSound);
			isPlayerJumping = false;
		}
		if (Input.GetKey(KeyCode.Space) && IsPlayerGrounded()) {
			player.audio.PlayOneShot(jumpSound);
			isPlayerJumping = true;
		}
		if (!IsPlayerGrounded()) {
			isPlayerJumping = true;
		}

		//walk sounds
		Vector3 deltaVelocity = (player.transform.position - lastPlayerPosition) / Time.deltaTime;;
		if (Mathf.Abs(deltaVelocity.x) >= walkingVelocityMargin && IsPlayerGrounded()) {
			if (player.audio.clip == null || !audio.clip.Equals(walkSound)) {
				player.audio.clip = walkSound;
				player.audio.loop = true;
				player.audio.Play();
			}
		} else {
			player.audio.clip = null;
			player.audio.loop = false;
		}
		lastPlayerPosition = player.transform.position;
	}

	private bool IsPlayerGrounded() {
		return ((CharacterMotor)player.GetComponent("CharacterMotor")).grounded;
	}
}
