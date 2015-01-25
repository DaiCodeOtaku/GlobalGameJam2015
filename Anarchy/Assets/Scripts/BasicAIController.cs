using UnityEngine;
using System.Collections;

public class BasicAIController : MonoBehaviour {

	public ProjectileConrtoller projectile;
	public float fireDelay = 3;
	public float velocity = 50.0f;
	float delay;
	
	// Use this for initialization
	void Start () {
		delay = fireDelay;
		fireDelay += Random.Range(0,10);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject mob = GameObject.FindGameObjectWithTag("Mob");
		Vector3 mobVector = mob.transform.position - this.transform.position;
		mobVector.y *= -1;
		RaycastHit hit;
		Debug.DrawRay(this.transform.position, mobVector);
		if((Vector3.Magnitude(mob.transform.position - this.transform.position)) <= 15){
			if (Physics.Raycast(this.transform.position, mobVector, out hit, Mathf.Infinity)){
				if(hit.transform.gameObject.CompareTag("Mob")){
					mobVector = mobVector.normalized;
					rigidbody.velocity = mobVector;
					if(fireDelay <= 0){
						ProjectileConrtoller PC = (ProjectileConrtoller)GameObject.Instantiate(projectile);
						PC.owner = this.gameObject;
						PC.Direction = mobVector * velocity;
						PC.transform.Translate(this.transform.position + (0.5f*mobVector));
						PC.transform.LookAt(PC.transform.position + PC.Direction, Vector3.up);
						fireDelay = delay;
					}
				}
				this.transform.LookAt(mob.transform.position);
				this.transform.Rotate(Vector3.up, 180);
			}
		}
		fireDelay -= Time.deltaTime;
	}
}
