using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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

	public Speech NewSpeech(List<Vector2> bubbles){
		Speech NewSpeech = (Speech)GameObject.Instantiate(speechCreator);
		NewSpeech.transform.position = mob.transform.position - new Vector3(0,-2,0);
		NewSpeech.transform.parent = mob.transform;
		NewSpeech.transform.LookAt(Camera.main.gameObject.transform.position);
		NewSpeech.transform.Rotate(transform.right, 90);
		NewSpeech.TexPos = 0;
		NewSpeech.ExistTime = 3;
		NewSpeech.bubbles = bubbles;
		return NewSpeech;
	}
	
	public Speech speechCreator;


	public objective Objectives;
	public Objective objectiveCreator;
	public MobController mob;

	private float delay;


	
	// Use this for initialization
	void Start () {
		Objectives = new objective();
		Objectives.states = state.completed;
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		mob = (MobController)GameObject.FindObjectOfType<MobController> ();
		Objective newObjective;
		List<Vector2> bubbles = new List<Vector2>();
		switch (Objectives.states) {
		case state.completed:
			//Make crowd go "yay"
			if(delay <= 0)
			{
				bubbles.Add(new Vector2(0,7));
				bubbles.Add(new Vector2(1,7));
				bubbles.Add(new Vector2(0,4));
				NewSpeech(bubbles);
				delay = 10;
			}
			delay -= Time.deltaTime;
			//newSpeech = NewSpeech (newSpeech, 1, 7);
			if(delay <= 0)
			{
				Objectives.states = state.needed;
			}
			break;
		case state.needed:
			//if(GameObject.FindWithTag("Objective") == null){
				//newSpeech = (Speech)GameObject.Instantiate(speechCreator); //PUT THIS SHIT IN WHEN "WE SHOULD DO THIS" BUBBaLE IS AVAILIBLE
			newObjective = (Objective)GameObject.Instantiate (objectiveCreator);
			//newSpeech.tag = "Speech";
			newObjective.tag = "Objective";
			
			Objectives.missions = Objectives.getObjective();
			//Objectives.missions = mission.test;
			
			switch (Objectives.missions)
			{
			case mission.bakery:
				//Make crowd say "WE RAID THE BAKERY!"
				newObjective.name = "bakeryObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(0,7));
				newObjective.name = "bakeryObjective";
				break;
			case mission.fences:
				newObjective.name = "fencesObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(0,7));
				newObjective.name = "fencesObjective";
				break;
			case mission.flowers:
				newObjective.name = "flowersObjective";
				bubbles.Add(new Vector2(0,7));
				newObjective.transform.parent = transform;
				newObjective.name = "flowersObjective";
				break;
			case mission.fountain:
				newObjective.name = "fountainObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(0,7));
				newObjective.name = "fountainObjective";
				break;
			case mission.graffiti:
				newObjective.name = "graffitiObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(0,7));
				newObjective.name = "graffitiObjective";
				break;
			case mission.knock:
				newObjective.name = "knockObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "knockObjective";
				bubbles.Add(new Vector2(0,7));
				break;
			case mission.mowing:
				newObjective.name = "mowingObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "mowingObjective";
				bubbles.Add(new Vector2(0,7));
				break;
			case mission.pee:
				newObjective.name = "peeObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "peeObjective";
				bubbles.Add(new Vector2(0,7));
				break;
			case mission.pigeons:
				newObjective.name = "pigeonObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "pigeonObjective";
				bubbles.Add(new Vector2(0,7));
				break;
			case mission.pub:
				newObjective.name = "pubObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "pubObjective";
				bubbles.Add(new Vector2(0,7));
				break;
			case mission.sheep:
				newObjective.name = "sheepObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "sheepObjective";
				bubbles.Add(new Vector2(0,7));
				break;
			case mission.shout:
				newObjective.name = "shoutObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "shoutObjective";
				bubbles.Add(new Vector2(0,7));
				break;
			case mission.traffic:
				newObjective.name = "trafficObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "trafficObjective";
				bubbles.Add(new Vector2(0,7));
				break;
			case mission.wigs:
				newObjective.name = "wigsObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "wigsObjective";
				bubbles.Add(new Vector2(0,7));
				break;
			case mission.test:
				newObjective.transform.parent = transform;
				newObjective.name = "testObjective";
				bubbles.Add(new Vector2(0,7));
				//newObjective.transform.position = 
				break;
			default:
				break;
				
			}
			NewSpeech(bubbles);
			Objectives.states = state.inProgress;
		//}
		
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