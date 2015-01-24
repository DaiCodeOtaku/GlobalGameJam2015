using UnityEngine;
using System.Collections;

public class ProjectileConrtoller : MonoBehaviour {

	public Vector3 Direction;
	public GameObject owner;
	private float timeToLive = 10;

	// Use this for initialization
	void Start () {
		this.rigidbody.velocity = Direction;
	}
	
	// Update is called once per frame
	void Update () {
		timeToLive -= Time.deltaTime;
		if(timeToLive < 0.0f)
		{
			Destroy(gameObject);

		}
		//this.transform.Translate(Direction * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		Health health = (Health)collision.gameObject.GetComponent<Health>();
		if (health != null){
			if(health.gameObject != owner){
				health.health--;			
				Destroy(this.gameObject);
			}
		} else {
			Destroy(this.gameObject);
		}
	}
}
