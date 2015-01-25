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

	public static Speech NewSpeech(Speech speechPrefab,List<Vector2> bubbles){
		Speech NewSpeech = (Speech)GameObject.Instantiate(speechPrefab);
		MobController mob = (MobController)GameObject.FindObjectOfType<MobController>();
		NewSpeech.transform.position = mob.transform.position - new Vector3(0,-2,0);
		NewSpeech.transform.parent = mob.transform;
		NewSpeech.TexPos = 0;
		NewSpeech.ExistTime = 3;
		NewSpeech.bubbles = bubbles;
		return NewSpeech;
	}
	
	void Start () {

	}
	
	
	void Update () {
		transform.LookAt(Camera.main.gameObject.transform.position, Vector3.forward);
		transform.Rotate(transform.right, -90);
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
	
	

