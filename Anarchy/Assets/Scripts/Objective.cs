using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {
	public MobController mob;
	//public Camera camera;
	Vector3 mobLocation;
	Vector3 objectiveLocation;
	float time;
	int buttonCount = 0;
	int keyPress;

	// Use this for initialization
	void Start () {
		time = 5.0f;
		mob = (MobController)GameObject.FindObjectOfType<MobController> ();

	}
	
	// Update is called once per frame
	void Update () {
	//DO MISSION STUFF HERE
		mobLocation = mob.transform.position;
    	objectiveLocation = this.transform.position;
		float distance = Vector3.Magnitude(mobLocation - objectiveLocation);
		switch (this.name) {
		case "bakeryObjective":
			if (distance <= 4.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "fencesObjective": // <-- button mash
			if (distance <= 4.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "flowersObjective": // <-- walk over
			if (distance <= 1.0)
			{
				Destroy(this.gameObject);
			}
			break;
		case "fountainObjective": 
			if (distance <= 4.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "graffitiObjective": // <--- Go to place, hold down A DONE
			if (distance <= 4.0)
			{
				if(Input.GetKey(KeyCode.JoystickButton0))
				{
					Debug.Log(time);
					time -= Time.deltaTime;
				}
				if(time <= 0)
				{
					Destroy(this.gameObject);
					Debug.Log("DESTROYED");
				}

			}
			break;
		case "knockObjective": // <-- Go to place, A 3 times, run. DONE
			if (distance <= 4.0)
			{
				if (Input.GetKeyDown(KeyCode.JoystickButton0))
				{
					Debug.Log(buttonCount);
					buttonCount++;
				}
				if(buttonCount >= 3)
				{
					Destroy(this.gameObject);
					Debug.Log("DESTROYED");
				}

			}
			break;
		case "mowingObjective": //<--- go to place, hold A, move around DONE
			if (distance <= 4.0)
			{
				if (Input.GetKey(KeyCode.JoystickButton0) && mob.rigidbody.velocity.magnitude > 1.0f)
				{
					time -= Time.deltaTime;
				}
				if (time <= 0)
				{
					Destroy(this.gameObject);
					Debug.Log("DESTROYED");
				}

			}
			break;
		case "peeObjective": // DONE
			if (distance <= 4.0)
			{
				time -= Time.deltaTime;
			
				if(time <= 0){
					Destroy(this.gameObject);
				}
			}
			break;
		case "pigeonObjective": // DONE
			if (distance <= 5.0 && mob.rigidbody.velocity.magnitude > 10)
			{
				Destroy(this.gameObject);
				//Debug.Log("DESTROYED");
			}
			break;
		case "pubObjective":  // DONE
			if (distance <= 3.0)
			{
				time -= Time.deltaTime;
				//cameraTime += Time.deltaTime;
				//Try to make a figure of 8, good luck
				//Camera.transform.Translate = (Mathf.Pow(cameraTime,2)*(Mathf.Pow (camera.transform.position.x,2)-Mathf.Pow(camera.transform.position.y,2)));

				//camera.transform.LookAt (mob.transform.position);

				if(time <= 0)
				{
					Destroy(this.gameObject);
				}
			}
			break;
		case "sheepObjective": // DONE
			if (distance <= 4.0 && mob.rigidbody.velocity.magnitude < 3 && mob.rigidbody.velocity.magnitude > 1)
			{
				Destroy(this.gameObject);
			}
			break;
		case "shoutObjective": // <-- Go to place, button mash, ???, win DONE
			if (distance <= 6.0)
			{
				if (Input.GetKeyDown(KeyCode.JoystickButton0))
				{
					Debug.Log(buttonCount);
					buttonCount++;
				}
				if(buttonCount >= 5)
				{
					Destroy(this.gameObject);
					Debug.Log("DESTROYED");
				}

			}
			break;
		case "trafficObjective": // <-- go to place, stand for 10 seconds, shoot cars and AIs DONE
			if (distance <= 5.0)
			{
				time -= Time.deltaTime;
				if( time <= 0)
				{
					Destroy(this.gameObject);
				}
			}
			break;
		case "wigsObjective": // 
			if (distance <= 4.0)
			{
				Destroy(this.gameObject);
				Debug.Log("DESTROYED");
			}
			break;
		case "flamingoObjective":
			if (distance <= 4.0)
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
