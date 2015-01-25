using UnityEngine;
using System.Collections;

public class AISpawner : MonoBehaviour {

	public BasicAIController BAI;
	public AdvAIController AAI;

	public float baseSpawnRate = 1;
	public float spawnRadius = 10;
	public float advAISpawnModifier = 2;
	public float basicAISpawnModifier = 4;

	private float delay = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject mob = GameObject.FindGameObjectWithTag("Mob");
		//if((Random.Range(0, 1000) * baseSpawnRate * basicAISpawnModifier * 1/(Vector3.Magnitude(mob.transform.position - this.transform.position))) >= 990){
		/*if((Random.Range(0, 1000)) <= (0.1  * baseSpawnRate * basicAISpawnModifier) + 1/(Vector3.Magnitude(mob.transform.position - this.transform.position))){
			BAI.transform.position = new Vector3(Random.Range(-50.0f,50.0f), 0, Random.Range(-50.0f,50.0f));
			BAI.transform.position = Random.value * spawnRadius * BAI.transform.position.normalized;
			BAI.transform.position = new Vector3(this.transform.position.x + BAI.transform.position.x, 10, this.transform.position.z + BAI.transform.position.z);
			RaycastHit hit;
			if(Physics.Raycast(BAI.transform.position, Vector3.down, out hit)){
				if(hit.transform.CompareTag("Terrain")){
					BAI.transform.position = hit.transform.position;
					if(Vector3.Magnitude(mob.transform.position - BAI.transform.position) < 12){
						Instantiate(BAI);
					}
				}
			}
		}
		if((Random.Range(0, 1000)) <= (0.1 * baseSpawnRate * advAISpawnModifier) + 1/(Vector3.Magnitude(mob.transform.position - this.transform.position))){
		//if((Random.Range(0, 1000) * baseSpawnRate * advAISpawnModifier * 1/(Vector3.Magnitude(mob.transform.position - this.transform.position))) >= 990){
			AAI.transform.position = new Vector3(Random.Range(-50.0f,50.0f), 0, Random.Range(-50.0f,50.0f));
			AAI.transform.position = Random.value * spawnRadius * AAI.transform.position.normalized;
			AAI.transform.position = new Vector3(this.transform.position.x + AAI.transform.position.x, 10, this.transform.position.z + AAI.transform.position.z);
			RaycastHit hit;
			if(Physics.Raycast(AAI.transform.position, Vector3.down, out hit)){
				if(hit.transform.CompareTag("Terrain")){
					AAI.transform.position = hit.transform.position;
					if(Vector3.Magnitude(mob.transform.position - AAI.transform.position) < 12){
						Instantiate(AAI);
					}
				}
			}
		}*/
		if(Vector3.Distance(mob.transform.position, transform.position) > 10)
		{
			if(delay < 0)
			{
				GameObject ai;
				if(Random.value < 0.3f)
				{
					ai = ((AdvAIController)GameObject.Instantiate(AAI)).gameObject;

				}else
				{
					ai = ((BasicAIController)GameObject.Instantiate(BAI)).gameObject;
				}
				ai.transform.position = transform.position + (new Vector3(Random.value -0.5f,0,Random.value -0.5f).normalized * spawnRadius * Random.value);
				delay = baseSpawnRate + ((Random.value-0.5f)*2.0f);
			}
		}
		delay -= Time.deltaTime;
	}
}
