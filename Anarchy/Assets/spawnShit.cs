using UnityEngine;
using System.Collections;

public class spawnShit : MonoBehaviour {

	public GameObject basic;
	public GameObject advance;

	float delay = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(delay < 0)
		{
			GameObject obj;
			if(Random.value < 0.5f)
			{
				obj = (GameObject)GameObject.Instantiate(basic);

			}else
			{
				obj = (GameObject)GameObject.Instantiate(advance);

			}
			obj.transform.position = new Vector3(Random.value * 200, 6, Random.value * 200);
			delay = 5;
		}
		delay -= Time.deltaTime;
	}
}
