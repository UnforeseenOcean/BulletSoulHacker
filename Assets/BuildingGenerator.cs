using UnityEngine;
using System.Collections;

public class BuildingGenerator : MonoBehaviour {
	
	public GameObject tunnel1;
	public GameObject tunnel2;
	public GameObject tunnel3;
	private float speed=2f;
	public GameObject player;
	private GameObject currentObj1;
	private GameObject currentObj2;
	public static bool initialJump=false;
	public static bool rivalWin=false;
	public static GameObject soundManager;
	
	private Vector3 currentPlayerY;
	private Vector3 oldPlayerY;
	

	private int randNumber=0;
	public GameObject weaponCam;
	public GameObject groupBuild;
	public static Transform playerTrans;
	public static Transform groundPlayTrans;
	public static Transform nodeTrans;
	public static GameObject camObj;
	
	public static int nodeOpportunity=0;
	public static int nodeObtained=0;
	
	private float distance=0f;
	
	public GameObject mainLight;
	
	public GameObject rival;
	public static bool rivalAlive=false;
	public static Transform rivalTrans;
	public GameObject healthNode;
	
	public static bool intro=true;
	public static bool outro=false;
	
	public GameObject sceneObj;
	public GameObject sceneLight;
	
	public GameObject uiObj;
	
	public static int mode=0;
	
	public GameObject building1;
	
	private bool once=true;
	// Use this for initialization
	void Start () {
		
		
		oldPlayerY=player.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(nodeOpportunity==3)
		{
			player.SetActive (false);
			outro=true;
		}
		
		if(intro || outro || AdrenalineScript.mainMenu || AdrenalineScript.lost)
		{
			if(intro)
			{
				uiObj.SetActive (false);
				player.SetActive (false);
				SoundScript.nowPlaying=5;
				sceneObj.SetActive(true);
				sceneLight.GetComponent<IntroScript>().enabled=true;
			}
			
			else if(outro)
			{
				uiObj.SetActive (false);
				player.SetActive (false);
				SoundScript.nowPlaying=6;
				sceneObj.SetActive(true);
				sceneLight.GetComponent<OutroScript>().enabled=true;
			}
		}
	else
		{
		if(once)
		{
		player.SetActive (true);
		uiObj.SetActive(true);
		playerTrans=player.transform;
		camObj=weaponCam;
		SmoothLookAt.player=playerTrans;
		SoulTransport.dirLight=mainLight.GetComponent<Light>();
		once=false;
		}
		
		if(!AdrenalineScript.playerDead)
		{
		
		if(initialJump)
		{
		if(SoulTransport.onGround)
				{
						if(groundPlayTrans!=null)
					{
					groupBuild.transform.position=new Vector3(groundPlayTrans.position.x,groundPlayTrans.position.y,groundPlayTrans.position.z);
					}
				}
				else
				{
					groupBuild.transform.position=new Vector3(playerTrans.position.x,playerTrans.position.y,playerTrans.position.z);
				}
		}
		//player.transform.position=new Vector3(player.transform.position.x,player.transform.position.y-speed,player.transform.position.z);
		currentPlayerY=player.transform.position;
	/*	if(Vector3.Distance(oldPlayerY,currentPlayerY) >=50f)
		{
			Instantiate (enemy,new Vector3(Random.Range (player.transform.position.x-100f,player.transform.position.x+100f),player.transform.position.y+10f,Random.Range (player.transform.position.z-100f,player.transform.position.z+100f)),Quaternion.identity);
		}*/
			
		distance=Vector3.Distance(oldPlayerY,currentPlayerY);
			
		if(distance/AdrenalineScript.lifeCount>=6)
			{
				if(Random.value<0.02)
				{
					Instantiate (healthNode,new Vector3(player.transform.position.x+Random.Range(-50f,50f),player.transform.position.y-200f,player.transform.position.z+Random.Range(-50f,50f)),Quaternion.identity);
				}
			}
				
				if(building1!=null)
				{
			if(Vector3.Distance (building1.transform.position,player.transform.position)>=300f)
				{
					Destroy (building1);
				}
				}
			
		if(distance >=300f)
		{
			if(CheckpointGenerator.checkpointCount>=1)
				{
					rivalAlive=true;
				}
			//Debug.Log ("Old Player"+oldPlayerY);
			//Debug.Log (Vector3.Distance(oldPlayerY,currentPlayerY));
		for(int i=0;i<8;i++)
		{
			randNumber=Random.Range (0,3);
			if(randNumber==0)
			{
				currentObj1=tunnel1;
			}
			else if(randNumber==1)
			{
				currentObj1=tunnel2;
			}
			else
					{
						currentObj1=tunnel3;
					}
						
			Instantiate(currentObj1,new Vector3(player.transform.position.x+Random.Range(-50f,50f),player.transform.position.y-400f,player.transform.position.z+Random.Range(-50f,50f)),Quaternion.identity);
			//currentObj1.transform.parent=groupBuild.transform;
			//	Instantiate(currentObj2,new Vector3(player.transform.position.x+Random.Range(-100f,100f),player.transform.position.y-200f,player.transform.position.z+Random.Range(-100f,100f)),Quaternion.identity);
				
			}
			//Instantiate (groupBuild,new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z),Quaternion.identity);
		oldPlayerY=currentPlayerY;	
		}
			
		}
			
			
		}
		
	
	}
}
