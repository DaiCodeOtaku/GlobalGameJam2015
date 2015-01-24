using UnityEngine;
using System.Collections;

public class Speech : MonoBehaviour {
	
	public Texture[] Tex;
	int TexPos;
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
		renderer.material.mainTexture = Tex[Pos];
	}
}
	
	

