using UnityEngine;
using System.Collections;

public class MuzzleFire : MonoBehaviour {
	
	
	private float alpha=0f;
	private Color currentColor= new Color(1, 1, 1, 0.0f);
	// Use this for initialization
	void Start () {
		
		alpha=0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton (0))
		{
			alpha=1f;
			currentColor.a=alpha;
			gameObject.GetComponent<Renderer>().material.SetColor ("_TintColor",currentColor);
				
		}
		
		else
		{
			alpha=0f;
			currentColor.a=alpha;
			gameObject.GetComponent<Renderer>().material.SetColor ("_TintColor",currentColor);
		}
		
	
	}
}
