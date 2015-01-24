using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector3 start;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		start = transform.position - transform.parent.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
		direction += new Vector3(Input.GetAxis("FireX"), 0.0f, Input.GetAxis("FireY"));
		direction *= 2;
		offset = Vector3.Lerp(offset, direction, Time.deltaTime);
		transform.position = offset + start + transform.parent.position;
	}
}
