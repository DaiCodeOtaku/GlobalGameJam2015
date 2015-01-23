using UnityEngine;
using System.Collections;

public class Speach : MonoBehaviour {
	public float ExistTime; 

	float Time1;
	float Time2;
	// Use this for initialization
	void Start () {
		Time1 = Time.time;
		Time2 = Time.time + ExistTime;

	}
	
	// Update is called once per frame
	void Update () {
		Time1 = Time.time;

		if(Time1 >= Time2)
		{
			Destroy(gameObject);
		}
	}
}
