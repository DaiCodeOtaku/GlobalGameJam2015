using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {

	public ProjectileConrtoller projectile;
	private float fireDelay = 0;
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
			PC.transform.Translate(this.transform.position + (1.1f*direction));
			PC.transform.LookAt(PC.transform.position + PC.Direction, Vector3.up);
			fireDelay = 0.2f;
		}
		fireDelay -= Time.deltaTime;
	}
}
