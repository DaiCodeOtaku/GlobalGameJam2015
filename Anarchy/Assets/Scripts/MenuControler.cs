using UnityEngine;
using System.Collections;

public class MenuControler : MonoBehaviour {


	public void LoadMain()
	{
		Application.LoadLevel("Anarchy");
	}

	public void LoadMenu()
	{
		Application.LoadLevel("Menu");
	}

	public void Exit()
	{
		Application.Quit();
	}



}
