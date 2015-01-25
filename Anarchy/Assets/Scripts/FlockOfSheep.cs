using UnityEngine;
using System.Collections;

public class FlockOfSheep : MonoBehaviour {

	bool uncomfortable = false;
	float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(uncomfortable){
			timer -= Time.deltaTime;
			if (timer <= 0){
				uncomfortable = false;
			}
		}
	}

	public void UncomfortSheep(){
		uncomfortable = true;
		rigidbody.velocity = Vector3.up;
		timer = 1;
	}

}
