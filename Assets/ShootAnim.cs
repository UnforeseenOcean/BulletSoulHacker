using UnityEngine;
using System.Collections;

public class ShootAnim : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!AdrenalineScript.playerDead)
		{
		
		if(gameObject.name=="revolver")
		{
			if(Input.GetMouseButton (0))
			{
				gameObject.GetComponent<Animation>().Play ("revolverAnim");
			}
		}
		
		if(gameObject.name=="dualrevolver")
		{
			if(Input.GetMouseButton (0))
			{
				gameObject.GetComponent<Animation>().Play ("dualrevolverAnim");
			}
		}
		if(gameObject.name=="katana")
		{
			if(Input.GetMouseButton (0))
			{
				gameObject.GetComponent<Animation>().Play ("katana");
			}
		}
		
		if(gameObject.name=="shotgun")
		{
			if(Input.GetMouseButton (0))
			{
				gameObject.GetComponent<Animation>().Play ("shotgunAnim");
			}
		}
		
		if(gameObject.name=="laser")
		{
			if(Input.GetMouseButton (0))
			{
				gameObject.GetComponent<Animation>().Play ("GunLaser");
			}
			
		}
		
		if(gameObject.name=="sniper")
		{
			if(Input.GetMouseButton (0))
			{
				gameObject.GetComponent<Animation>().Play ("SniperShoot");
			}
			
		}
			
			if(gameObject.name=="Socom")
		{
			if(Input.GetMouseButton (0))
			{
				gameObject.GetComponent<Animation>().Play ("SocomAnim");
			}
			
		}
		}
	
	}
}
