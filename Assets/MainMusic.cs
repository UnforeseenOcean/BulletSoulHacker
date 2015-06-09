using UnityEngine;
using System.Collections;

public class MainMusic : MonoBehaviour {
	
	public AudioSource main;
	public AudioClip slower;
	public AudioClip faster;
	
	private float timer=0f;
	private bool slowOnce=true;
	private bool fastOnce=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		timer+=Time.deltaTime;
		
		Debug.Log (main.time);
		
		if(timer<86f)
		{
			if(slowOnce)
			{
			main.PlayOneShot(slower);
			slowOnce=false;
			fastOnce=true;
			}
		}
		else if(timer>86f && timer < 349f)
		{
			if(fastOnce)
			{
			main.PlayOneShot (faster);
			fastOnce=false;
			}
			
		}
		else if(timer>350f)
		{
		slowOnce=true;	
		 timer=0f;
		}
		
	
	}
}
