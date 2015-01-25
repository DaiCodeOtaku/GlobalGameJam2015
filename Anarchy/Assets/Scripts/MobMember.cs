using UnityEngine;
using System.Collections;

public class MobMember : MonoBehaviour {

	private float jiggleDelay = 0;
	public float scale = 1;
	Quaternion target;
	public Vector3 targetPosition;
	float offset;
	// Use this for initialization
	void Start () {
		target.eulerAngles = new Vector3(0,0,0);
		offset = Random.value * 2 * Mathf.PI;
	}
	
	// Update is called once per frame
	void Update () {
		if(jiggleDelay < 0)
		{
			target.eulerAngles = new Vector3((Random.value-0.5f) *20, 0, (Random.value-0.5f) *20);
			jiggleDelay = 1;
		}
		Vector3 relative = transform.position - transform.parent.transform.position;
		transform.position = transform.parent.transform.position + new Vector3(Mathf.Lerp(relative.x, targetPosition.x * scale, Time.deltaTime),Mathf.Abs(Mathf.Cos((Time.time * 5.0f) + offset)) * 0.08f* transform.parent.rigidbody.velocity.magnitude, Mathf.Lerp(relative.z, targetPosition.z*scale, Time.deltaTime));
		jiggleDelay -= Time.deltaTime * transform.parent.rigidbody.velocity.magnitude;
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * transform.parent.rigidbody.velocity.magnitude);

	}
}
