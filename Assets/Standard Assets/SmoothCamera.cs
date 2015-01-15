using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

	private float dampTime = 0.3f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	private bool _isZoomed = false;
	private Vector3 zoomChanged = new Vector3(0f, 0f, 25f);

	void Update () {
		if (!_isZoomed && Input.GetMouseButtonDown(1) && !GameObject.FindGameObjectWithTag("Player").GetComponent<EscScript>().isPaused()
		    && !GameObject.FindGameObjectWithTag("Player").GetComponent<EscScript>().GetWon()) {
			_isZoomed = true;
			transform.position -= zoomChanged;
		}
		else if (_isZoomed && Input.GetMouseButtonUp(1)) {
			_isZoomed = false;
			transform.position += zoomChanged;
		}

		if (target) {
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}

	public bool isZoomed() {
		return _isZoomed;
	}
}