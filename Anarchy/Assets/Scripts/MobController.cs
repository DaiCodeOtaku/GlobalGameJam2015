using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {

	public ProjectileConrtoller projectile;
	private float fireDelay = 0;
	public MobMember member;
	public GameObject startPos;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
		direction.Normalize();
		float scale =  Mathf.Clamp(Input.GetAxis("Squash"),-0.35f,-1.0f)*-1.0f;
		rigidbody.AddForce(direction * Time.deltaTime * 200 * scale);
		direction  = new Vector3(Input.GetAxis("FireX"),0,Input.GetAxis("FireY"));
		if(fireDelay < 0 && direction.normalized.magnitude > 0.0f ){
			ProjectileConrtoller PC = (ProjectileConrtoller)GameObject.Instantiate(projectile);
			PC.owner = this.gameObject;
			PC.Direction = direction.normalized*10.0f;
			PC.Direction += rigidbody.velocity/2.0f;
			PC.transform.position = this.transform.position+(Vector3.up*0.75f);
			PC.transform.position += new Vector3(Mathf.Clamp(direction.normalized.x, -0.5f, 0.5f), 0,Mathf.Clamp(direction.normalized.z, -0.5f, 0.5f)) * (((BoxCollider)collider).size.x+0.2f);
			PC.transform.LookAt(PC.transform.position + PC.Direction, Vector3.up);
			fireDelay = 0.1f;
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
				mem.transform.position = startPos.transform.position;
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
			for(int i = 0; i < members.Length; i++)
			{
				members[i].targetPosition = new Vector3(Random.Range(-radius,radius),0,Random.Range(-radius,radius))/2.0f;
			}
		}
		float rad = Mathf.Pow(members.Length,1/3.0f);
		rad = Mathf.Lerp(((BoxCollider)collider).size.x, rad*scale,Time.deltaTime);
		((BoxCollider)collider).size = new Vector3(rad, 0.9f, rad);
		for(int i =0 ; i < members.Length; i++)
		{
			members[i].scale = scale;

		}
	}
}
