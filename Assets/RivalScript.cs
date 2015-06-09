using UnityEngine;
using System.Collections;

public class RivalScript : MonoBehaviour {
	
	public static int life=30;
	private Transform player;
	private Transform node;
	private bool once=true;
	public static bool rivalAlive=false;
	
	
	private float moveTimer=0f;
	// Use this for initialization
	void Start () {
		
		life=30;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(once)
		{
		BuildingGenerator.rivalTrans=transform;
		player=BuildingGenerator.playerTrans;
		once=false;
		}
		
		if(BuildingGenerator.nodeTrans!=null)
		{
			node=BuildingGenerator.nodeTrans;
		}
		
		moveTimer+=Time.deltaTime;
		
		if(node!=null)
		{
			transform.position=Vector3.Lerp (transform.position,node.position,moveTimer/10f);
		}
		
		if(moveTimer>10f)
		{
			BuildingGenerator.rivalWin=true;
			Destroy (gameObject);
		}
		
		if(AdrenalineScript.lost)
		{
			Destroy (gameObject);
		}
		
/*		if(Vector3.Distance (transform.position,player.position)>=300f)
		{
			BuildingGenerator.rivalAlive=false;
			BuildingGenerator.rivalTrans=null;
			rivalAlive=false;
			Destroy (gameObject);
		}
			 */
	}
}
