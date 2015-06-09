using UnityEngine;
using System.Collections;

public class GroundPlayerScript : MonoBehaviour {
	
	public static float posY;
	private Transform player;
	
	private Vector3 onlyY;
	public GameObject aliveGround;
	public GameObject deadGround;
	private float waitTimer=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(AdrenalineScript.playerDead)
		{

			deadGround.SetActive (true);
			aliveGround.SetActive (false);
			
			if(SoulTransport.nearBody)
			{
					if(SoulTransport.onGround)
				{
				deadGround.SetActive (false);
				aliveGround.SetActive (true);
				}
			}
		}
		else
		{
			deadGround.SetActive (false);
			aliveGround.SetActive (true);
		}
		
		if(AdrenalineScript.lost)
		{
			Destroy (gameObject);
		}
		
		if(player==null)
		{
			player=BuildingGenerator.playerTrans;
		}
		if(BuildingGenerator.groundPlayTrans==null)
		{
			BuildingGenerator.groundPlayTrans=transform;
		}
		
		else
		{
			onlyY=new Vector3(0f,transform.position.y,0f);
			
			//Debug.Log (Vector3.Distance (onlyY,new Vector3(0f,posY,0f)));
			//Debug.Log (transform.position.y-posY);
		if(Vector3.Distance (onlyY,new Vector3(0f,posY,0f))>=40f)
		{
			player.gameObject.SetActive(true);
			SoulTransport.onGround=false;
			Destroy (gameObject);
			
		}
		}
		
		if(BuildingGenerator.outro)
		{
			SoulTransport.onGround=false;
			gameObject.SetActive (false);
		}
		if(waitTimer<2f)
		waitTimer+=Time.deltaTime;
		
		if(waitTimer>=2f)
		{
		if(!SoulTransport.onGround)
		{
			Destroy(gameObject);
		}
		}
			
		
	
	}
}
