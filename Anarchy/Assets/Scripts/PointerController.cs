using UnityEngine;
using System.Collections;

public class PointerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Objective obj = (Objective)GameObject.FindObjectOfType<Objective>();
		if(obj == null)
		{
			gameObject.GetComponentInChildren<Renderer>().enabled = false;

		}else
		{
			if(Vector3.Distance(transform.position, obj.transform.position) <10)
			{
				gameObject.GetComponentInChildren<Renderer>().enabled = false;
			}else
			{
				gameObject.GetComponentInChildren<Renderer>().enabled = true;
			}
			transform.LookAt(obj.transform.position, Vector3.up);
		}
	}
}
