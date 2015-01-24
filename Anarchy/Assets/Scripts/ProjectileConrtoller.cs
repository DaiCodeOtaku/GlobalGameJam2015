using UnityEngine;
using System.Collections;

public class ProjectileConrtoller : MonoBehaviour {

	public Vector3 Direction;

	// Use this for initialization
	void Start () {
		Direction = Vector3.right;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Direction * Time.deltaTime);

	}

	void OnCollisionEnter(Collision collision) {
		Health health = (Health)collision.gameObject.GetComponent<Health>();
		if (health != null){
			health.health--;
		}
		Destroy(this.gameObject);
	}
}
