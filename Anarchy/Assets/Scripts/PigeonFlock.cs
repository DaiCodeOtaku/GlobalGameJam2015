using UnityEngine;
using System.Collections;

public class PigeonFlock : MonoBehaviour {

	bool startled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(startled){
			this.transform.Translate(Vector3.up * Time.deltaTime);
		}
	}

	public void StartlePigeons(){
		startled = true;
	}
}

