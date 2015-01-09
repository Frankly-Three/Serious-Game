using UnityEngine;
using System.Collections;

public class Alien_Following : MonoBehaviour {

	public float smooth = 1.5f;

	private Transform player;
	private Vector3 relCameraPos;
	private float relCameraPosMag;
	private Vector3 newPos;

	void awake() {
		player = GameObject.FindGameObjectWithTag ("Graphics").transform;
		relCameraPos = transform.position - player.position;
		relCameraPosMag = relCameraPos.magnitude - 0.5f;
	}

	void FixedUpdate()
	{
		Vector3 standardPos = player.position + relCameraPos;
		Vector3 abovePos = player.position + Vector3.up * relCameraPosMag;
		Vector3[] checkpoints = new Vector3 [5];
		checkpoints [0] = standardPos;
		checkpoints [1] = Vector3.Lerp (standardPos, abovePos, 0.25f);
		checkpoints [2] = Vector3.Lerp (standardPos, abovePos, 0.5f);
		checkpoints [3] = Vector3.Lerp (standardPos, abovePos, 0.75f);
		checkpoints [4] = abovePos;

		for (int i = 0; i < checkpoints.Length; i ++) 
		{
			if (viewingPosCheck(checkpoints[i]))
			{
				break;
			}
		}


		transform.position = Vector3.Lerp (transform.position, newPos, smooth * Time.deltaTime);

		smoothLookAt ();

	}

	bool viewingPosCheck(Vector3 checkPos) 
	{
		transform.position = player.position + Vector3.up * Time.deltaTime;
		RaycastHit hit;

		if (Physics.Raycast(checkPos, player.position - checkPos, out hit, relCameraPosMag ))
		{
			if (hit.transform != player)
			{ 
				return false;
			}
		}
		newPos=checkPos;
		return true;
	}

	void smoothLookAt()
	{
		Vector3 relPlayerPos = player.position - transform.position;
		Quaternion lookAtRot = Quaternion.LookRotation (relPlayerPos, Vector3.up);
		transform.rotation = Quaternion.Lerp (transform.rotation, lookAtRot, Time.deltaTime);
	}


}
