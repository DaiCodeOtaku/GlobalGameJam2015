using UnityEngine;
using System.Collections;

public enum state {needed, completed, inProgress};
public enum mission {bakery, fences, flowers, pee, fountain, sheep, mowing, pigeons, knock, shout, traffic, graffiti, wigs, pub, test};



public class objective
{
	
	public state states;
	public mission missions;
	public mission lastMission;
	
	public mission getObjective ()
	{
		mission lastMission = missions;
		missions = (mission)Random.Range (1, 14);
		
		while (missions == lastMission){
			missions = (mission)Random.Range (1, 14);
		}
		return missions;
	}
	
}


public class ObjectiveController : MonoBehaviour {
	
	public float yayTime = 3.0f;
	public Speech speechCreator;
	public objective Objectives;
	public Objective objectiveCreator;
	public MobController mob;
	
	// Use this for initialization
	void Start () {
		Objectives = new objective();
		Objectives.states = state.needed;
		
	}
	
	// Update is called once per frame
	void Update () {
		mob = (MobController)GameObject.FindObjectOfType<MobController> ();
		
		Speech newSpeech;
		Objective newObjective;
		switch (Objectives.states) {
		case state.completed:
			yayTime -= Time.deltaTime;
			//Make crowd go "yay"
			if(GameObject.FindWithTag("Speech") == null){
				newSpeech = (Speech)GameObject.Instantiate(speechCreator);
				newSpeech.transform.position = mob.transform.position - new Vector3(0,-2,0);
				newSpeech.transform.parent = mob.transform;
				newSpeech.transform.LookAt(Camera.main.gameObject.transform.position);
				newSpeech.transform.Rotate(transform.right, 90);
				newSpeech.TexPos = 0;
				newSpeech.ExistTime = 3;
			}
			
			
			if (yayTime <= 0){
				//if (GameObject.FindWithTag("Speech") == null){
					// Make crowd say "So what do we do now?"
					Debug.Log("IHAH");
					newSpeech = (Speech)GameObject.Instantiate(speechCreator);
					newSpeech.transform.position = mob.transform.position - new Vector3(0,-2,0);
					newSpeech.transform.parent = mob.transform;
					newSpeech.transform.LookAt(Camera.main.gameObject.transform.position);
					newSpeech.transform.Rotate(-transform.right, -90);
					newSpeech.TexPos = 1;
					newSpeech.ExistTime = 3;
				//}
				yayTime = 3;
				Objectives.states = state.needed;
				
			}
			break;
		case state.needed:
			if(GameObject.FindWithTag("Objective") == null){
				//newSpeech = (Speech)GameObject.Instantiate(speechCreator); //PUT THIS SHIT IN WHEN "WE SHOULD DO THIS" BUBBaLE IS AVAILIBLE
				newObjective = (Objective)GameObject.Instantiate (objectiveCreator);
				//newSpeech.tag = "Speech";
				newObjective.tag = "Objective";
				
				Objectives.missions = Objectives.getObjective();
				Debug.Log("New mission created");
				//Objectives.missions = mission.test;
				switch (Objectives.missions)
				{
				case mission.bakery:
					//Make crowd say "WE RAID THE BAKERY!"
					newObjective.name = "bakeryObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "bakeryObjective";
					break;
				case mission.fences:
					newObjective.name = "fencesObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "fencesObjective";
					break;
				case mission.flowers:
					newObjective.name = "flowersObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "flowersObjective";
					break;
				case mission.fountain:
					newObjective.name = "fountainObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "fountainObjective";
					break;
				case mission.graffiti:
					newObjective.name = "graffitiObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "graffitiObjective";
					break;
				case mission.knock:
					newObjective.name = "knockObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "knockObjective";
					break;
				case mission.mowing:
					newObjective.name = "mowingObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "mowingObjective";
					break;
				case mission.pee:
					newObjective.name = "peeObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "peeObjective";
					break;
				case mission.pigeons:
					newObjective.name = "pigeonObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "pigeonObjective";
					break;
				case mission.pub:
					newObjective.name = "pubObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "pubObjective";
					break;
				case mission.sheep:
					newObjective.name = "sheepObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "sheepObjective";
					break;
				case mission.shout:
					newObjective.name = "shoutObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "shoutObjective";
					break;
				case mission.traffic:
					newObjective.name = "trafficObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "trafficObjective";
					break;
				case mission.wigs:
					newObjective.name = "wigsObjective";
					newObjective.transform.parent = transform;
					newObjective.name = "wigsObjective";
					break;
				case mission.test:
					newObjective.transform.parent = transform;
					newObjective.name = "testObjective";
					//newObjective.transform.position = 
					break;
				default:
					break;
					
				}
				Objectives.states = state.inProgress;
			}
			
			break;
		case state.inProgress:
			if(GameObject.FindObjectOfType<Objective>() == null){
				Objectives.states = state.completed;
				
			}
			break;
		default:
			break;
			
		}
		
		
		
	}
}