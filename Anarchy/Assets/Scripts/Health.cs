using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {
		health = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			Destroy(this.gameObject);
		}
	}
}
