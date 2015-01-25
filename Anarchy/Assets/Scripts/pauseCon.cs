using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Canvas))]
public class pauseCon : MonoBehaviour {
	public Canvas can;
	bool b1 =false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		
		
		if(Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Return))   
		{
			if(can.enabled == false){
				can.enabled = true;
				return ;
			}

			if(can.enabled == true){
				can.enabled = false;
				return ;
			}

		}



	}
}
