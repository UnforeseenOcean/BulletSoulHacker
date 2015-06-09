using UnityEngine;
using System.Collections;

public class MobotShoot : MonoBehaviour {
	public GameObject laser1;
	public GameObject laser2;
	public bool detect=false;
	private float resetTimer=0f;
	private float changeTimer=0f;
	
	private Transform player;
	
	private bool thrice=false;
	
	public Transform gun;
	private float shootTimer=0f;
	private Ray ray;
	public LineRenderer line;
	private bool once=true;
	private float deathTimer=0f;
	
	private GameObject weaponCam;
	private bool damage=false;
	private Vector3 targetPos;
	private float activeTimer=0f;
	public int life=10;
	private int enemyType=0;
	public GameObject mobot;
	public GameObject gunKyle;
	public GameObject swordKyle;
	public GameObject sniperKyle;
	public GameObject rival;
	
	private bool attack=false;
	// Use this for initialization
	void Start () {
		
	
	}
	
	void OnEnable()
	{
		if(gameObject==mobot)
		enemyType=1;
		else if(gameObject==gunKyle)
		{
		enemyType=2;
		//Debug.Log("GUN!");
		}
		else if(gameObject==swordKyle)
		enemyType=3;
		else if(gameObject==sniperKyle)
		enemyType=4;
		else if(gameObject==rival)
		enemyType=5;
		
		player=BuildingGenerator.playerTrans;
		
	}
	
	

	
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (enemyType);
		//Debug.Log (activeTimer);
		if(AdrenalineScript.lost)
		{
			Destroy (gameObject);
		}
		
		if(!AdrenalineScript.playerDead)
		{
		changeTimer+=Time.deltaTime;
		resetTimer+=Time.deltaTime;
		if(enemyType==1)
		{
		if(changeTimer>1f && changeTimer<2f)
		{
			laser1.SetActive (false);
			laser2.SetActive (true);
		}
		else if(changeTimer<1f)
		{
			laser1.SetActive (true);
			laser2.SetActive (false);
		}
		else
		{
			changeTimer=0f;
		}
		}
		
		if(resetTimer>2f)
		{
			detect=false;
			thrice=true;
			once=true;
			resetTimer=0f;
		}
//		Debug.Log (detect);
		if(detect)
		{
			//Debug.Log ("Player"+player);
			//Debug.Log (gameObject.name+" "+transform.position);
			deathTimer=0f;
			if(!SoulTransport.onGround)
			{
			if(enemyType!=3)
			{
			//Debug.Log (transform+"YEAH!");
			transform.position-=new Vector3(0f,1.2f,0f);
			}
			else
			{
			if(!attack)
			transform.position-=new Vector3(0f,1.05f,0f);
			}
			}
			
			
			shootTimer+=Time.deltaTime;
			//Debug.Log ("YEAH!!!!");
			player=BuildingGenerator.playerTrans;
			weaponCam=BuildingGenerator.camObj;
				if(shootTimer>2f)			{
				
				attack=true; //flag turned on
				
				if(enemyType!=3)
				{
				ray=new Ray(gun.transform.position,gun.transform.forward);
				line.SetPosition (0,ray.origin);
//		Debug.Log (player);
				if(SoulTransport.onGround)
						{
							targetPos=new Vector3(player.position.x+Random.Range (-10f,10f),player.position.y,player.position.z+Random.Range(-10f,10f));
						}
						else
						{
				targetPos=new Vector3(player.position.x+Random.Range (-10f,10f),player.position.y+Random.Range (-5f,5f),player.position.z+Random.Range(-10f,10f));
						}
				line.SetPosition(1,targetPos);
				if(Vector3.Distance(targetPos,player.position)<=5f)
				{
					//Debug.Log("DAMAGE");
					damage=true;
					AdrenalineScript.lifeCount-=5f;
				}
				}
				shootTimer=0f;
				
				
			}
					else
				{
						attack=false;
					}
			
			if(damage)
			{
				activeTimer+=Time.deltaTime;
		
		if(activeTimer<0.5f)
		{
			weaponCam.GetComponent<PP_Noise>().enabled=true;
		}
		else
		{
			weaponCam.GetComponent<PP_Noise>().enabled=false;
			activeTimer=0f;
			damage=false;
			
		}
			}
			
			if(line.enabled)
			{
				ray=new Ray(gun.transform.position,gun.transform.forward);
				line.SetPosition (0,ray.origin);	
			}
					
					if(attack)
				{
					if(enemyType==3)
				{
					transform.position=new Vector3(transform.position.x,player.position.y-5f,transform.position.z);
					transform.position=Vector3.Lerp (new Vector3(transform.position.x,player.position.y-5f,transform.position.z),player.position,Time.deltaTime);	
					if(Vector3.Distance (transform.position,player.position)<=10f)
					{
					damage=true;
					AdrenalineScript.lifeCount-=5f;
					
					attack=false;
					}
				}
				
		
		}
		}
		else
		{
			if(enemyType!=5)
				{
			transform.position-=new Vector3(0f,1.5f,0f);
			
			deathTimer+=Time.deltaTime;
			if(deathTimer>5f)
			{
				SoulTransport.enemyCount--;
				Destroy (gameObject);
			
			}
			}
		}
	}
		
		else
		{
			if(enemyType==2 || enemyType==4)
			{
			if(SoulTransport.onGround)
				{
					if(BuildingGenerator.groundPlayTrans!=null)
					{
					if(Vector3.Distance (transform.position,BuildingGenerator.groundPlayTrans.position)<=10f)
			{
				SoulTransport.enemy=transform.GetChild(0).gameObject;
				SoulTransport.nearBody=true;
			}
					}
				}
				else
				{
			if(Vector3.Distance (transform.position,player.position)<=10f)
			{
				SoulTransport.enemy=transform.GetChild(0).gameObject;
				SoulTransport.nearBody=true;
			}
			}
			}
		}
		
		
	}
	
	
	
	
}
