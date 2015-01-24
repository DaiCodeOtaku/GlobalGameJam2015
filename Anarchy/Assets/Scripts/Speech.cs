using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Speech : MonoBehaviour {

	public Texture[] Tex;
	public int TexPos;
	public float ExistTime; 
	float Time1;
	float Time2;
	
	
	void Start () {
		
		TextureSet(TexPos);
		Time1 = Time.time;
		Time2 = Time.time + ExistTime;

		
	}
	
	
	void Update () {
		Time1 = Time.time;



		if(Time1 >= Time2)
		{
			Destroy(gameObject);
		}
	}
	
	void TextureSet(int Pos)
	{
		renderer.material.SetTexture(0, Tex[Pos]);
		Debug.Log (Tex.ToString());
		Debug.Log (Pos);
		Debug.Log (TexPos);

	}
}
	
	

