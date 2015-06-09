using UnityEngine;
using System.Collections;

public class AnimPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		gameObject.GetComponent<Animation>().Play();
	
	}
}
