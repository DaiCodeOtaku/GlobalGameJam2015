using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {
	public MobController mob;
	Vector3 mobLocation;
	Vector3 objectiveLocation;
	float time;
	bool timeSwitch;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	//DO MISSION STUFF HERE
		mob = (MobController)GameObject.FindObjectOfType<MobController> ();
		mobLocation = mob.transform.position;
    	objectiveLocation = this.transform.position;
		float distance = Vector3.Magnitude(mobLocation - objectiveLocation);
		switch (this.name) {
		case "bakeryObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "fencesObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "flowerObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "fountainObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "graffitiObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "knockObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "mowingObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "peeObjective":
			/*if (distance <= 2.0)
			{
				if (timeSwitch == true){
					time -= Time.deltaTime;
				}
				if(time <= 0){
					Destroy(this.gameObject);
				}
			}
			else {
				timeSwitch = false;
			}*/if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "pigeonObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "pubObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "sheepObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "shoutObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "trafficObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "wigsObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "testObjective":
			if (distance <= 2.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		default:
			break;
		}

	}
}
