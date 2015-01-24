using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {

	public ProjectileConrtoller projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
		direction.Normalize();
		rigidbody.AddForce(direction * Time.deltaTime * 100);

		if(Random.Range(0, 1000) <= 10){
			ProjectileConrtoller PC = (ProjectileConrtoller)GameObject.Instantiate(projectile);
			PC.owner = this.gameObject;
			PC.Direction = new Vector3(Random.value-0.5f, 0, Random.value-0.5f).normalized;
			PC.transform.Translate(this.transform.position + (1*PC.Direction));
			PC.transform.LookAt(PC.transform.position + PC.Direction, Vector3.up);
			}
	}
}
