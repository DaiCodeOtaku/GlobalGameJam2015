using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Canvas))]
public class TutUI : MonoBehaviour {


	public Canvas can;
	// Use this for initialization
	void Start () {

		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Return))   
		{
			can.enabled = false;
			Time.timeScale = 1.0f;
		}




	}
}
