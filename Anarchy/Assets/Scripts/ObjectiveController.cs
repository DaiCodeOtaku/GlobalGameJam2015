using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum state {needed, completed, inProgress};
public enum mission {bakery, fences, flowers, pee, fountain, sheep, mowing, pigeons, knock, shout, traffic, graffiti, wigs, pub, test};



public class objective
{
	
	public state states;
	public mission missions;
	
	public mission getObjective ()
	{
		mission lastMission = missions;
		missions = (mission)Random.Range (1, 14);
		
		while (missions == lastMission){
			missions = (mission)Random.Range (1, 14);
		}
		//missions = mission.pee;
		return missions;
	}
	
}

 


public class ObjectiveController : MonoBehaviour {

	public Speech speechCreator;


	public objective Objectives;
	public Objective objectiveCreator;
	public GameObject River;
	public GameObject Pigeon;
	public GameObject Sheep;
	public GameObject Pub;

	private float delay;


	
	// Use this for initialization
	void Start () {
		Objectives = new objective();
		Objectives.states = state.completed;
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//mob = (MobController)GameObject.FindObjectOfType<MobController> ();
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
				Speech.NewSpeech(speechCreator,bubbles);
				FindObjectOfType<MobController>().GetComponent<Health>().health += 10;

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
				bubbles.Add(new Vector2(1,4));
				newObjective.name = "bakeryObjective";
				break;
			case mission.fences:
				newObjective.name = "fencesObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(2,4));
				newObjective.name = "fencesObjective";
				break;
			case mission.flowers:
				newObjective.name = "flowersObjective";
				bubbles.Add(new Vector2(3,4));
				newObjective.transform.parent = transform;
				newObjective.name = "flowersObjective";
				break;
			case mission.fountain:
				newObjective.name = "fountainObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(5,4));
				newObjective.name = "fountainObjective";
				break;
			case mission.graffiti:
				newObjective.name = "graffitiObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(5,3));
				newObjective.name = "graffitiObjective";
				break;
			case mission.knock:
				newObjective.name = "knockObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "knockObjective";
				bubbles.Add(new Vector2(2,3));
				break;
			case mission.mowing:
				newObjective.name = "mowingObjective";
				newObjective.transform.parent = transform;
				newObjective.name = "mowingObjective";
				bubbles.Add(new Vector2(0,3));
				break;
			case mission.pee:
				newObjective.name = "peeObjective";
				River = GameObject.FindWithTag("River");;
				newObjective.transform.position = River.transform.position; // DONE
				newObjective.name = "peeObjective";
				bubbles.Add(new Vector2(4,4));
				break;
			case mission.pigeons:
				newObjective.name = "pigeonObjective";
				Pigeon = GameObject.FindWithTag("Pigeon");;
				newObjective.transform.position = Pigeon.transform.position; // DONE
				bubbles.Add(new Vector2(1,3));
				break;
			case mission.pub:
				newObjective.name = "pubObjective";
				Pub = GameObject.FindWithTag("Pub");;
				newObjective.transform.position = Pub.transform.position; // DONE;
				bubbles.Add(new Vector2(0,2));
				break;
			case mission.sheep:
				newObjective.name = "sheepObjective";
				Sheep = GameObject.FindWithTag("Sheep");;
				newObjective.transform.position = Sheep.transform.position; // DONE
				bubbles.Add(new Vector2(6,4));
				break;
			case mission.shout:
				newObjective.name = "shoutObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(3,3));
				break;
			case mission.traffic:
				newObjective.name = "trafficObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(4,3));
				break;
			case mission.wigs:
				newObjective.name = "wigsObjective";
				newObjective.transform.parent = transform;
				bubbles.Add(new Vector2(6,3));
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
			Speech.NewSpeech(speechCreator,bubbles);
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