using UnityEngine;
using System.Collections;

public class AdvAIController : MonoBehaviour {

	public ProjectileConrtoller projectile;
	public float fireDelay = 3.0f;
	public float velocity = 50.0f;
	public int burst = 3;
	public float burstDelay = 0.1f;
	int iterations = 10;

	float delay;
	int burstAmount;
	
	// Use this for initialization
	void Start () {
		delay = fireDelay;
		burstAmount = burst;
		fireDelay += Random.Range(0,10);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject mob = GameObject.FindGameObjectWithTag("Mob");
		Vector3 mobVector = mob.transform.position - this.transform.position;
		RaycastHit hit;
		this.transform.LookAt(mob.transform.position);
		//Debug.DrawRay(this.transform.position, mobVector);
		if(Mathf.Abs(Vector3.Magnitude(mob.transform.position - this.transform.position)) <= 10){
			if (Physics.Raycast(this.transform.position, mobVector, out hit, Mathf.Infinity)){
				if(hit.collider == mob.collider){
					mobVector = mobVector.normalized;
					rigidbody.velocity = mobVector;
					if(fireDelay <= 0){
						ProjectileConrtoller PC = (ProjectileConrtoller)GameObject.Instantiate(projectile);
						PC.owner = this.gameObject;
						PC.Direction = mobVector * velocity;
						PC.transform.Translate(this.transform.position + (1.1f*mobVector));
						PC.transform.LookAt(PC.transform.position + PC.Direction, Vector3.up);
						fireDelay = burstDelay;
						burst--;
						if(burst == 0){
							burst = burstAmount;
							fireDelay = delay;
						}
					}
				} else {
					AdvancedPathfinding(hit, mobVector, mobVector, 0);
				}
			}
		}
		fireDelay -= Time.deltaTime;
	}

	void AdvancedPathfinding(RaycastHit originalHit, Vector3 mobVectorL, Vector3 mobVectorR, int its){
		if(its <= iterations){

			RaycastHit hit;
			Vector3 mobRotLeft = Quaternion.AngleAxis(-10, Vector3.up) * mobVectorL;
			Vector3 mobRotRight = Quaternion.AngleAxis(10, Vector3.up) * mobVectorR;
			bool moreLeft = false;
			bool moreRight = false;

			if(Physics.Raycast(this.transform.position, mobRotLeft, out hit, Mathf.Infinity)){
				if(hit.collider != originalHit.collider){
					mobRotLeft = mobRotLeft.normalized;
					rigidbody.velocity = mobRotLeft;
					//Debug.Log("New Collider Left");
				} else {
					moreLeft = true;
				}
			} else {

				mobRotLeft = mobRotLeft.normalized;
				rigidbody.velocity = mobRotLeft - this.transform.right;
				//Debug.Log("No Hit Left");
			}

			if(Physics.Raycast(this.transform.position, mobRotRight, out hit, Mathf.Infinity)){
				if(hit.collider != originalHit.collider){
					mobRotLeft = mobRotRight.normalized;
					rigidbody.velocity = mobRotRight;
					//Debug.Log("new Cllider Right");
				} else {
					moreRight = true;
				}
			} else {
				mobRotLeft = mobRotRight.normalized;
				rigidbody.velocity = mobRotRight + this.transform.right;
				//Debug.Log("No Hit Right");
			}

			if(moreLeft && moreRight){

				AdvancedPathfinding(originalHit, mobRotLeft, mobRotRight, its++);
			}
		}
	}
}
























