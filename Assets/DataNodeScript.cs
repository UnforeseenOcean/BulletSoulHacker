using UnityEngine;
using System.Collections;

public class DataNodeScript : MonoBehaviour {
	
	private Transform groundTrans;
	private Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(BuildingGenerator.groundPlayTrans!=null)
		{
		groundTrans=BuildingGenerator.groundPlayTrans;
		}
		
		if(BuildingGenerator.playerTrans!=null)
		{
			player=BuildingGenerator.playerTrans;
		}
		if(BuildingGenerator.nodeTrans!=null)
		{
			BuildingGenerator.nodeTrans=transform;
		}
		
		if(groundTrans!=null)
		{
		if(Vector3.Distance (transform.position,groundTrans.position)<=22f)
		{
			BuildingGenerator.nodeObtained++;
			SoulTransport.onGround=false;
			AdrenalineScript.timeLeft+=20f;
			groundTrans.gameObject.SetActive (false);
			player.gameObject.SetActive(true);
			Destroy (gameObject);
		}
			if(BuildingGenerator.rivalWin)
			{
			SoulTransport.onGround=false;
			AdrenalineScript.timeLeft+=10f;
			groundTrans.gameObject.SetActive (false);
			player.gameObject.SetActive(true);
			Destroy (gameObject);
			}
		}
		
		if(AdrenalineScript.lost)
		{
			Destroy (gameObject);
		}
	
	}
}
