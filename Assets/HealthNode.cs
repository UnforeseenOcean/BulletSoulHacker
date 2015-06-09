using UnityEngine;
using System.Collections;

public class HealthNode : MonoBehaviour {
	
	private Transform player;
	private float destroyTimer=0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(player==null)
		{
			player=BuildingGenerator.playerTrans;
		}
		else
		{
		destroyTimer+=Time.deltaTime;
			if(destroyTimer>5f)
			{
				Destroy (gameObject);
			}
		if(Vector3.Distance (transform.position,player.position)<=5f)
		{
			AdrenalineScript.lifeCount+=10f;
			AdrenalineScript.lifeGained=true;
			Destroy (gameObject);
		}
		}
		if(AdrenalineScript.lost)
		{
			Destroy (gameObject);
		}
	}
}
