using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {
	
	private float destroyTimer=0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		destroyTimer+=Time.deltaTime;
		
		if(destroyTimer>5f)
		{
			Destroy (gameObject);
		}
	
	}
}
