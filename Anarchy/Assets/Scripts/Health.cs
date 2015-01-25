using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			Destroy(this.gameObject); //oliver has changed this
			//Time.timeScale = 0.0f;
		}
	}
}
