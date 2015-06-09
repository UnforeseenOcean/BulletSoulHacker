using UnityEngine;
using System.Collections;

public class TunnelScript : MonoBehaviour {
	
	private Transform groundTrans;
	
	private float destroyTimer=0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		destroyTimer+=Time.deltaTime;
		if(destroyTimer>20f)
		{
			Destroy(gameObject);
		}
		
		if(SoulTransport.onGround)
		{
			if(BuildingGenerator.groundPlayTrans!=null)
			{
				groundTrans=BuildingGenerator.groundPlayTrans;
			}
			
			if(groundTrans!=null)
			{
				if(Vector3.Distance (transform.position,groundTrans.position)<=100f)
				{
					Destroy(gameObject);
				}
			}
		}
	
	}
}
