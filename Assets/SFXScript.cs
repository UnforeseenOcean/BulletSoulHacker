using UnityEngine;
using System.Collections;

public class SFXScript : MonoBehaviour {
	
	public AudioClip gunSound;
	private AudioSource source;
	private AudioSource dualSource;
	private float repeatTimer=0f;
	private bool repeatAllow=false;
	
	private GameObject soundMan;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(soundMan==null)
		{
			soundMan=BuildingGenerator.soundManager;
		}
		else
		{
		if(source==null || dualSource==null)
		{
				source=soundMan.transform.FindChild ("Gunshots").gameObject.GetComponent<AudioSource>();
				dualSource=soundMan.transform.FindChild ("DualGunshots").gameObject.GetComponent<AudioSource>();
		}
		}
		
		if(!repeatAllow)
		{
			repeatTimer+=Time.deltaTime;
			
			if(repeatTimer>0.3f)
			{
				repeatAllow=true;
				repeatTimer=0f;
			}
		}
		else
		{
			if(Input.GetMouseButton (0))
			{
				source.PlayOneShot (gunSound);
				repeatAllow=false;
			}
		}
	}
}
