using UnityEngine;
using System.Collections;

public class BasicAIController : MonoBehaviour {

	public ProjectileConrtoller projectile;
	public float fireDelay;
	public float velocity = 50.0f;
	
	// Use this for initialization
	void Start () {
		fireDelay += Random.Range(0,10);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject mob = GameObject.FindGameObjectWithTag("Mob");
		Vector3 mobVector = mob.transform.position - this.transform.position;
		RaycastHit hit;
		//Debug.DrawRay(this.transform.position, mobVector);
		if(Mathf.Abs(Vector3.Magnitude(mob.transform.position - this.transform.position)) <= 20){
			if (Physics.Raycast(this.transform.position, mobVector, out hit, Mathf.Infinity)){
				if(hit.transform.gameObject.CompareTag("Mob")){
					mobVector = mobVector.normalized;
					rigidbody.velocity = mobVector;
					if(fireDelay <= 0){
						ProjectileConrtoller PC = (ProjectileConrtoller)GameObject.Instantiate(projectile);
						PC.owner = this.gameObject;
						PC.Direction = mobVector * velocity;
						PC.transform.Translate(this.transform.position + (1.1f*mobVector));
						PC.transform.LookAt(PC.transform.position + PC.Direction, Vector3.up);
						fireDelay = 3.0f;
					}
				}
			}
		}
		fireDelay -= Time.deltaTime;
	}
}
