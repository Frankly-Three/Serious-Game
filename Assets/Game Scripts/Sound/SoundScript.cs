using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	public float raycastMargin = 0.1f;

	public AudioClip jumpSound;
	public AudioClip touchDownSound;

	private GameObject player;
	private bool isPlayerJumping;

	// Use this for initialization
	void Start () {
	
	}

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerJumping && IsPlayerGrounded()) {
			audio.PlayOneShot(touchDownSound);
			isPlayerJumping = false;
		}
		if (Input.GetKey(KeyCode.Space) && IsPlayerGrounded()) {
			audio.PlayOneShot(jumpSound);
			isPlayerJumping = true;
		}
		if (!IsPlayerGrounded()) {
			isPlayerJumping = true;
		}
	}

	private bool IsPlayerGrounded() {
		return Physics.Raycast(player.transform.position, -Vector3.up, player.collider.bounds.extents.y + raycastMargin);
	}
}
