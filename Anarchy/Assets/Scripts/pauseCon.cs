using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Canvas))]
public class pauseCon : MonoBehaviour {
	public Canvas can;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		
		
		if(Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Return))   
		{
			if(can.enabled == false){
				can.enabled = true;
				Time.timeScale = 0.0f;
				return ;
			}

			if(can.enabled == true){
				can.enabled = false;
				Time.timeScale = 1.0f;
				return ;
			}

		}



	}
}
