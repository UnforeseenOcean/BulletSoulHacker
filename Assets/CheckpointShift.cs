using UnityEngine;
using System.Collections;

public class CheckpointShift : MonoBehaviour {
	

	private Transform player;
	private Vector3 newPos;
	public GameObject corridor1;
	public GameObject corridor2;
	private int randCorridor=0;
	public GameObject groundPlayer;
	public GameObject rival;
	private Transform rivalTrans;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(player==null)
		{
			player=BuildingGenerator.playerTrans;
		}
		else
		{
			//Debug.Log (Vector3.Distance (transform.position,player.position));
			
			
		
		if(player.position.y-transform.position.y<10f)
		{
			//checkpoint achieved
			AdrenalineScript.timeLeft+=25f;
			AdrenalineScript.timeGained=true;
			newPos=new Vector3(CheckpointGenerator.currentCheckpoint.transform.position.x,CheckpointGenerator.currentCheckpoint.transform.position.y-30f,CheckpointGenerator.currentCheckpoint.transform.position.z);
			AdrenalineScript.lifeCount+=25f;	
				
			if(CheckpointGenerator.checkpointCount>=1)
			{
					randCorridor=Random.Range (1,3);
				if(randCorridor==1)
				{
						Instantiate (corridor1,newPos,Quaternion.identity);
				}
					else if(randCorridor==2)
					{
						Instantiate (corridor2,newPos,Quaternion.identity);
					}
					if(BuildingGenerator.rivalAlive)
					{
						Debug.Log ("RIVAL SPAWNED!");
						Instantiate (rival,new Vector3(newPos.x+5f,newPos.y+10f,newPos.z),Quaternion.identity);
					}
			Instantiate (groundPlayer,new Vector3(newPos.x,newPos.y+5f,newPos.z),Quaternion.identity);
			GroundPlayerScript.posY=newPos.y+5f;
			BuildingGenerator.nodeOpportunity++;
			player.gameObject.SetActive (false);
			SoulTransport.onGround=true;
			CheckpointGenerator.checkpointCount=0;
			}
			
			player.position=groundPlayer.transform.position;
			
			CheckpointGenerator.checkpointAlive=false;
			CheckpointGenerator.checkpointCount++;
			Destroy (gameObject.transform.parent.gameObject);
			
		}
		}
		
		if(AdrenalineScript.lost)
		{
			CheckpointGenerator.checkpointAlive=false;
			CheckpointGenerator.checkpointCount=0;
			Destroy (gameObject);
		}
	}
	
	
}
