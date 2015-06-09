using UnityEngine;
using System.Collections;

public class ModeActivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	
	void Update()
	{
		if(Input.GetMouseButton (0))
		{
			//Debug.Log ("INSIDE UPDATe");
			OnClick ();
		}
	}
	
	void OnClick()
	{
		//Debug.Log("THIS WORKS");
		if(gameObject.name=="StoryMode")
		{
			BuildingGenerator.mode=1;
		}
		if(gameObject.name=="ArcadeMode")
		{
			BuildingGenerator.mode=2;
		}
		if(gameObject.name=="ExperimentalMode")
		{
			BuildingGenerator.mode=3;			
		}
		
	}
}
