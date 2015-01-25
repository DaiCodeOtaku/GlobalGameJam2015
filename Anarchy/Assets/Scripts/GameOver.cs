using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Canvas))]
public class GameOver : MonoBehaviour {
	public Canvas can;
	float score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		MobController mob =(MobController)GameObject.FindObjectOfType <MobController>();
		
		score =(mob.GetComponent("Health") as Health).health; 

		if(score < 1)
		{
			can.enabled = true;
		}

	}
}
