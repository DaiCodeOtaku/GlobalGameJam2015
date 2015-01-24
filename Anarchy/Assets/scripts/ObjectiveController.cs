using UnityEngine;
using System.Collections;

public enum state {needed, completed, inProgress};
public enum mission {bakery, fences, flowers, pee, fountain, sheep, mowing, pigeons, knock, shout, traffic, graffiti, wigs, pub};



public class objective
{

	public state states;
	public mission missions;
	public mission lastMission;

	public void getObjective (mission missions)
	{
		mission lastMission = missions;
		missions = (mission)Random.Range (1, 14);

		while (missions == lastMission){
			missions = (mission)Random.Range (1, 14);
		}
	}

}


public class ObjectiveController : MonoBehaviour {

	public float yayTime = 5;
	public GameObject speech;
	public Objective Objective;


	// Use this for initialization
	void Start () {
		objective objectives = new objective();

		if (objectives.states == state.needed) {
			objectives.getObjective(objectives.missions);
		}
	}
	
	// Update is called once per frame
	void Update () {
		objective objectives = new objective();

		
		if (objectives.states == state.needed) {
			objectives.getObjective(objectives.missions);
			switch (objectives.missions)
			{
			case mission.bakery:
				//Make crowd say "WE RAID THE BAKERY!"
				speech = new GameObject("speechBakery");
				speech.AddComponent("TexPos");

				Objective newObjective = (Objective)GameObject.Instantiate(Objective);
				newObjective.tag = "Objective";

				break;
			case mission.fences:

				break;
			case mission.flowers:

				break;
			case mission.fountain:

				break;
			case mission.graffiti:

				break;
			case mission.knock:

				break;
			case mission.mowing:

				break;
			case mission.pee:

				break;
			case mission.pigeons:

				break;
			case mission.pub:

				break;
			case mission.sheep:

				break;
			case mission.shout:

				break;
			case mission.traffic:

				break;
			case mission.wigs:

				break;
			default:
				break;
			}
		}

		if (objectives.states == state.inProgress) {
			//detect if objective is completed, then update the state
			if(GameObject.FindGameObjectsWithTag("Objective") == null){
				objectives.states = state.completed;
			}
		}
		
		if (objectives.states == state.completed) {
			//Make crowd go "yay"
			yayTime -= Time.deltaTime;
			if (yayTime <= 0){
				// Make crowd say "So what do we do now?"
				objectives.states = state.needed;

			}
		}

	}
}
