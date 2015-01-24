using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

	public ProjectileConrtoller projectile;
	float fireDelay;
	public LayerMask layerMask;

	// Use this for initialization
	void Start () {
		fireDelay = 3;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject mob = GameObject.FindGameObjectWithTag("Mob");
		Vector3 mobVector = mob.transform.position - this.transform.position;
		RaycastHit hit;
		Debug.DrawRay(this.transform.position, mobVector); 
		if (Physics.Raycast(this.transform.position, mobVector, out hit, Mathf.Infinity)){
			if((hit.transform.gameObject.CompareTag("Mob")) || (hit.transform.gameObject.CompareTag("Projectile"))){
				mobVector = mobVector.normalized;
				rigidbody.velocity = mobVector;
				if(fireDelay <= 0){
					Debug.Log("Fire!");
					ProjectileConrtoller PC = (ProjectileConrtoller)GameObject.Instantiate(projectile);
					PC.owner = this.gameObject;
					PC.Direction = mobVector*50.0f;
					PC.transform.Translate(this.transform.position + (1.1f*mobVector));
					PC.transform.LookAt(PC.transform.position + PC.Direction, Vector3.up);
					fireDelay = 3.0f;
				}
			}
		}
		fireDelay -= Time.deltaTime;
	}
}
