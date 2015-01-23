using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
		direction.Normalize();
		rigidbody.AddForce(direction * Time.deltaTime * 100);
		                        
	}
}
