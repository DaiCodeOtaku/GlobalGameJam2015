using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Speech : MonoBehaviour {

	public Texture[] Tex;
	public int TexPos;
	public float ExistTime; 
	public List<Vector2> bubbles;
	public float delay;
	public Vector2 texCoords;

	
	
	void Start () {

	}
	
	
	void Update () {
		if(delay < 0)
		{
			if(bubbles.Count > 0)
			{
				Vector2 bubble = bubbles[0];
				bubbles.Remove(bubble);
				texCoords.Set(0,0);
				for (int i = 0; i < bubble.x; i++) {
					texCoords.x += 0.125f;
				}
				for (int i = 0; i < bubble.y; i++) {
					texCoords.y += 0.125f;	
				}
				renderer.material.SetTextureOffset ("_MainTex", texCoords);
				//TextureSet(TexPos);
				delay = ExistTime;
			}else
			{
				Destroy(gameObject);
			}
		}
		delay -= Time.deltaTime;
	}
	
	void TextureSet(int Pos)
	{

		renderer.material.SetTexture(0, Tex[Pos]);
	}
}
	
	

