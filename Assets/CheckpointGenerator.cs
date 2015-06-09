using UnityEngine;
using System.Collections;

public class CheckpointGenerator : MonoBehaviour {
	
	private Transform player;
	public GameObject checkpoint;
	
	public static GameObject currentCheckpoint;
	public static int checkpointCount=0;
	public static bool checkpointAlive=false;
	private Vector3 oldCheckpointPos;
	private Vector3 normalizedPos;
	private Vector3 newPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(player==null)
		{
			player=BuildingGenerator.playerTrans;
			if(player!=null)
			{
				oldCheckpointPos=player.position;
				normalizedPos=oldCheckpointPos;
			}
		}
		else
		{
		
		if(Vector3.Distance (oldCheckpointPos,player.position)>=50f)
		{
				if(!checkpointAlive)
				{
			Debug.Log("CHECKPOINT GENERATED!");
			newPos=new Vector3(normalizedPos.x,player.position.y-400f,normalizedPos.z);
			currentCheckpoint=Instantiate (checkpoint,newPos,Quaternion.identity)as GameObject;
				checkpointAlive=true;
			oldCheckpointPos=newPos;
				}
		}
		}
	
	}
}
