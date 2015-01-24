using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {

	public ProjectileConrtoller projectile;
	private float fireDelay = 0;
	public MobMember member;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
		direction.Normalize();
		rigidbody.AddForce(direction * Time.deltaTime * 200);
		direction  = new Vector3(Input.GetAxis("FireX"),0,Input.GetAxis("FireY")).normalized;
		if(fireDelay < 0 && direction.magnitude > 0.0f ){
			ProjectileConrtoller PC = (ProjectileConrtoller)GameObject.Instantiate(projectile);
			PC.owner = this.gameObject;
			PC.Direction = direction*30.0f;
			PC.Direction += rigidbody.velocity;
			PC.transform.Translate(this.transform.position + (direction * ((BoxCollider)collider).size.x)+(Vector3.up*0.75f));
			PC.transform.LookAt(PC.transform.position + PC.Direction, Vector3.up);
			fireDelay = 0.2f;
		}
		fireDelay -= Time.deltaTime;
		MobMember[] members;
		members = gameObject.GetComponentsInChildren<MobMember>();
		if(GetComponent<Health>().health != members.Length)
		{
			float change = GetComponent<Health>().health - members.Length;
			while(change > 0)
			{
				MobMember mem = (MobMember)GameObject.Instantiate(member);
				mem.transform.parent = transform;
				change--;
			}
			while(change < 0)
			{
				members[members.Length-1].transform.parent =null;
				members[members.Length-1].transform.rotation = Quaternion.AngleAxis(Random.value * 360.0f,Vector3.up) * Quaternion.AngleAxis(90,Vector3.left);
				members[members.Length-1].transform.position = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
				Destroy(members[members.Length-1]);
				change++;
			}
			members = gameObject.GetComponentsInChildren<MobMember>();
			float radius = Mathf.Pow(members.Length,1/3.0f);
			((BoxCollider)collider).size = new Vector3(radius, 0.9f, radius);
			for(int i = 0; i < members.Length; i++)
			{
				members[i].targetPosition = new Vector3(Random.Range(-radius,radius),0,Random.Range(-radius,radius))/2.0f;
			}
		}
	}
}
