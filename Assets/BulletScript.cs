using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public static int difficultyLevel=0;
	
	private Transform player;
	private float destroyTimer=0f;
	
	private bool once=true;
	private float ranX=0f;
	private float ranY=0f;
	private float ranZ=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		player=BuildingGenerator.playerTrans;
	}
	
	// Update is called once per frame
	void Update () {
		
		destroyTimer+=Time.deltaTime;
		
		if(destroyTimer>3f)
		{
			Destroy (gameObject);
		}
		if(once)
		{
		ranX=Random.Range (-10f,10f);
		ranY=Random.Range (-5f,5f);
		ranZ=Random.Range (-10f,10f);
		once=false;
		}
		
		transform.position=Vector3.Lerp(transform.position,new Vector3(player.position.x+ranX,player.position.y+ranY,player.position.z+ranZ),Time.deltaTime);
		transform.LookAt (player);
	}
}
