using UnityEngine;
using System.Collections;

public class ScoreUpdater : MonoBehaviour {
	public UnityEngine.UI.Text tex;
	string score;
	int Health;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		tex = gameObject.GetComponent("Text") as UnityEngine.UI.Text;
		MobController mob =(MobController)GameObject.FindObjectOfType <MobController>();

		score =(mob.GetComponent("Health") as Health).health.ToString(); 
		//get health from somewhere
		tex.text = score;



	}
}
