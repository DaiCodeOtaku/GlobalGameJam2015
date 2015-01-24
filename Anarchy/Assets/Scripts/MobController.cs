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
		rigidbody.AddForce(direction * Time.deltaTime * 100);
		direction  = new Vector3(Input.GetAxis("FireX"),0,Input.GetAxis("FireY")).normalized;
		if(fireDelay < 0 && direction.magnitude > 0.0f ){
			ProjectileConrtoller PC = (ProjectileConrtoller)GameObject.Instantiate(projectile);
			PC.owner = this.gameObject;
			PC.Direction = direction*10.0f;
			PC.Direction += rigidbody.velocity;
			PC.transform.Translate(this.transform.position + (direction * ((BoxCollider)collider).size.x));
			PC.transform.LookAt(PC.transform.position + PC.Direction, Vector3.up);
			fireDelay = 0.2f;
		}
		fireDelay -= Time.deltaTime;
		MobMember[] members;
		members = gameObject.GetComponentsInChildren<MobMember>();
		float radius = Mathf.Pow(members.Length,1/3.0f);
		if(((BoxCollider)collider).size.x != radius)
		{
			((BoxCollider)collider).size = new Vector3(radius, 1.8f, radius);
			for(int i = 0; i < members.Length; i++)
			{
				members[i].transform.position = new Vector3(Random.Range(-radius,radius),0,Random.Range(-radius,radius))/2.0f + transform.position;
			}
		}
		if(Input.GetKeyDown("space"))
		{

			MobMember mem = (MobMember)GameObject.Instantiate(member);
			mem.transform.parent = transform;
		}
	}
}
