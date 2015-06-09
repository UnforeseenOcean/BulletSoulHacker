using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {
	
	private Ray ray;
	private RaycastHit hit;
	private Transform target;
	private GameObject enemy;
	private int layerMask;
	public GameObject energyBlast;
	public GameObject bigBlast;
	
	public LineRenderer line;
	private Ray gunRay;
	public GameObject gun;
	public static int weapon=0;
	public Camera mainCam;
	
	private Vector3 endRay;
	
	public GameObject laser1;
	public GameObject laser2;
	private float changeTimer=0f;
	
	private float hitDist=80f;
	
	public DynamicSoundGroup sfxManager;

	// Use this for initialization
	void Start () {
		
		layerMask= 1 << 10;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!AdrenalineScript.playerDead)
		{
		
		if(weapon!=6)
		{
		if(AdrenalineScript.acqPositive==4)
		{
			hitDist=120f;
		}
		else
		{
			hitDist=80f;
		}
		}
		else
		{
			hitDist=15f;
		}
		
		
		ray=mainCam.ScreenPointToRay (new Vector3(Screen.width/2f,Screen.height/2f,0));
		if(Input.GetMouseButton(0))
		{
			endRay=mainCam.WorldToScreenPoint(new Vector3(Screen.width/2f,Screen.height/2f,0));
			
			
			if(weapon==5)
		{
			line.enabled=true;
			gunRay=new Ray(laser1.transform.position,laser1.transform.forward);
			line.SetPosition (0,gunRay.origin);
			line.SetPosition (1,gunRay.origin+transform.forward*100f);
		changeTimer+=Time.deltaTime;				
				
				if(changeTimer>0.5f && changeTimer<1f)
		{
			laser1.SetActive (false);
			laser2.SetActive (true);
		}
		else if(changeTimer<0.25f)
		{
			laser1.SetActive (true);
			laser2.SetActive (false);
		}
		else
		{
			changeTimer=0f;
		}
			
		}
			else
			{
				line.enabled=false;
			}
					
			if(Physics.Raycast(ray,out hit,100f,layerMask))
			{
			
			//Debug.Log("Hit");
			target=hit.transform;
			
		//	Instantiate (playerBullets,new Vector3(mainCam.transform.position.x,mainCam.transform.position.y-1f,mainCam.transform.position.z),Quaternion.identity);
			enemy=hit.transform.gameObject;
				
				if(enemy!=null)
				{
					
					//Debug.Log (enemy);
					if(enemy.name=="MOBOT")
					{
					enemy.transform.parent.gameObject.GetComponent<MobotShoot>().life--;
					if(enemy.transform.parent.gameObject.GetComponent<MobotShoot>().life<=0)
					{
					//Debug.Log ("DEAD!!!!!");
					Instantiate (bigBlast,enemy.transform.position,Quaternion.identity);
					SoulTransport.enemy=enemy;
					}
					}
					else if(enemy.name=="GunKyle")
					{
					//Debug.Log ("YEAH!!!");
					enemy.transform.parent.gameObject.GetComponent<MobotShoot>().life--;
					if(enemy.transform.parent.gameObject.GetComponent<MobotShoot>().life<=0)
					{
					//Debug.Log ("DEAD!!!!!");
					Instantiate (bigBlast,enemy.transform.position,Quaternion.identity);
					SoulTransport.enemy=enemy;
					}
					}
					else if(enemy.name=="SwordKyle")
					{
					enemy.transform.parent.gameObject.GetComponent<MobotShoot>().life--;
					if(enemy.transform.parent.gameObject.GetComponent<MobotShoot>().life<=0)
					{
					//Debug.Log ("DEAD!!!!!");
					Instantiate (bigBlast,enemy.transform.position,Quaternion.identity);
					SoulTransport.enemy=enemy;
					}
					}
					else if(enemy.name=="SniperKyle")
					{
					enemy.transform.parent.gameObject.GetComponent<MobotShoot>().life--;
					if(enemy.transform.parent.gameObject.GetComponent<MobotShoot>().life<=0)
					{
					//Debug.Log ("DEAD!!!!!");
					Instantiate (bigBlast,enemy.transform.position,Quaternion.identity);
					SoulTransport.enemy=enemy;
					}
					}	
						else if(enemy.name=="Rival")
					{
					RivalScript.life-=5;
					if(RivalScript.life<=0)
					{
					//Debug.Log ("DEAD!!!!!");
					Instantiate (bigBlast,enemy.transform.position,Quaternion.identity);
					SoulTransport.enemy=enemy.transform.GetChild (0).gameObject;
					}
					}	
					//Debug.Log ("YEAH!");
					Instantiate (energyBlast,enemy.transform.position,Quaternion.identity);
					//Debug.Log(enemy.transform.parent.gameObject.GetComponent<AttackMode>().resurrect);
					//Debug.Log ("YES!");
					
					
			/*	if(enemy.GetComponent<EnemyLife>()!=null)
				{
						
				if(!enemy.GetComponent<EnemyLife>().death)	
				{
							
				enemy.GetComponent<EnemyLife>().life-=5f;
				}*/
				}
				
			}
		}
		else
		{
			if(weapon==5)
			{
				line.enabled=false;
			}
		}
	}
	}
}
