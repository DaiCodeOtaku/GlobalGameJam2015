using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)){
			if(hit.collider.gameObject == gameObject)
			{
				renderer.material.shader = Shader.Find("Transparent/Diffuse");
				renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,0.5f);

			}else
			{
				renderer.material.shader = Shader.Find("Diffuse");
				renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,1.0f);

			}
		}
	}
}
