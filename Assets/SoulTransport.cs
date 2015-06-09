using UnityEngine;
using System.Collections;

public class SoulTransport : MonoBehaviour {
	
	public static GameObject enemy;
	public static bool allow=false;
	private CharacterController control;
	private float shiftTimer=0f;
	
	public GameObject mobot;
	public GameObject swordKyle;
	public GameObject gunKyle;
	public GameObject sniperKyle;
	private int randEnemy;
	public static int enemyCount=0;
	private float spawnTimer=0f;
	
	private float animTime=0f;
	
	private new Color pinkAmb;
	private new Color blueAmb;
	private new Color greenAmb;
	private new Color yellowAmb;
	private new Color redAmb;
	
	private new Color pinkFog;
	private new Color blueFog;
	private new Color greenFog;
	private new Color yellowFog;
	private new Color redFog;
	public GameObject weaponCam;
	
	
	public GameObject revolver;
	public GameObject dualrevolver;
	public GameObject shotgun;
	public GameObject laser;
	public GameObject katana;
	public GameObject sniper;
	
	public GameObject fpsCam;
	private int randAmbient=0;
	private int randWeapon=0;
	
	public static int enemyType=0;
	
	public static bool nearBody=false;
	
	public static bool onGround=false;
	
	private float spawnSeldom=0f;
	
	public static bool shifting=false;
	

	
	public static Light dirLight;
	// Use this for initialization
	void Start () {
		
		control=gameObject.GetComponent<CharacterController>();
		weaponCam.GetComponent<PP_LightWave>().enabled=false;
		weaponCam.GetComponent<PP_RadialBlur>().enabled=false;
		
		dualrevolver.SetActive (true);
		revolver.SetActive (true);
		shotgun.SetActive (false);
		laser.SetActive (false);
		katana.SetActive (false);
		sniper.SetActive (false);
		
		pinkAmb=new Color(308f,255f,255f);
		blueAmb=new Color(187f,255f,255f);
		greenAmb=new Color(132f,255f,255f);
		yellowAmb=new Color(63f,255f,255f);
		redAmb=new Color(353f,255f,255f);
		
		((DepthOfFieldScatter)(weaponCam.GetComponent<DepthOfFieldScatter>())).enabled=false;
		
		
		
	}

	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log(control.isGrounded);
		
		if(!AdrenalineScript.playerDead)
		{
		//Debug.Log ("Enemy Type"+enemyType);
		if(BuildingGenerator.initialJump)
		{
		if(!control.isGrounded && !onGround)
		{
			transform.position-=new Vector3(0f,1f,0f);
				//Debug.Log("ENEMY GEN!");
				spawnTimer+=Time.deltaTime;		//Instantiate Enemies
				if(enemyCount<7)
				{
				if(spawnTimer>1f)
				{
					randEnemy=Random.Range (0,4);
					if(randEnemy==0)
					Instantiate (mobot,new Vector3(transform.position.x+Random.Range (0f,30f),transform.position.y-Random.Range (-10f,30f),transform.position.z+Random.Range(-20f,20f)),Quaternion.identity);
					else if(randEnemy==1)
					Instantiate (gunKyle,new Vector3(transform.position.x+Random.Range (-20f,30f),transform.position.y-Random.Range (-10f,30f),transform.position.z+Random.Range(-20f,20f)),Quaternion.identity);	
					else if(randEnemy==2)
					Instantiate (swordKyle,new Vector3(transform.position.x+Random.Range (-20f,30f),transform.position.y-Random.Range (-10f,30f),transform.position.z+Random.Range(-20f,20f)),Quaternion.identity);
					else if(randEnemy==3)
					Instantiate (sniperKyle,new Vector3(transform.position.x+Random.Range (-20f,30f),transform.position.y-Random.Range (-10f,30f),transform.position.z+Random.Range(-20f,20f)),Quaternion.identity);
					enemyCount++;
							
					spawnTimer=0f;
				}
				}
		}
				else
				{

				}
		}
		else
		{
			gameObject.GetComponent<Animation>().Play ("InitialJump");
			animTime+=Time.deltaTime;
			if(animTime>10f)
			{
				gameObject.GetComponent<vp_FPInput>().enabled=true;
				gameObject.GetComponent<vp_FPController>().enabled=true;
				gameObject.transform.FindChild ("FPSCamera").gameObject.GetComponent<vp_FPCamera>().enabled=true;
				BuildingGenerator.initialJump=true;
			}
				
				 //CHANGE THIS
				/*gameObject.GetComponent<vp_FPInput>().enabled=true;
				gameObject.GetComponent<vp_FPController>().enabled=true;
				gameObject.transform.FindChild ("FPSCamera").gameObject.GetComponent<vp_FPCamera>().enabled=true;
				initialJump=true;*/
		}
		
		if(enemy!=null)
		{
			if(onGround)
				{
					transform.position=Vector3.Lerp (transform.position,new Vector3(enemy.transform.position.x,enemy.transform.position.y+5f,enemy.transform.position.z),shiftTimer*2f);
				}
				else
				{
					shifting=true;
			//MoveObject (gameObject.transform,transform.position,enemy.transform.position,100f);
    		transform.position=Vector3.Lerp (transform.position,enemy.transform.position,shiftTimer*2f);
				}
    		shiftTimer+=Time.deltaTime;
			//fpsCam.camera.enabled=false;
			weaponCam.GetComponent<PP_LightWave>().enabled=true;
			weaponCam.GetComponent<PP_RadialBlur>().enabled=true;
			if(shiftTimer>0.5f)
			{
				weaponCam.GetComponent<PP_LightWave>().enabled=false;
			weaponCam.GetComponent<PP_RadialBlur>().enabled=false;
				//fpsCam.camera.enabled=true;
				//	Debug.Log ("MOVE IT!");
				shiftTimer=0f;
				StartCoroutine ("EnemyBody");
				
		}
				
			
		}
		}
		else
		{
			spawnSeldom+=Time.deltaTime;
			if(spawnSeldom>5f)
			{
				Instantiate (gunKyle,new Vector3(transform.position.x+Random.Range (-10f,20f),transform.position.y+Random.Range (-20f,20f),transform.position.z+Random.Range (-20f,20f)),Quaternion.identity);
				spawnSeldom=0f;
			}
			if(nearBody)
			{
				shifting=true;
				transform.position=Vector3.Lerp (transform.position,enemy.transform.position,shiftTimer/1f);
    		shiftTimer+=Time.deltaTime;
				
			AdrenalineScript.lifeCount=50f;
				
			weaponCam.GetComponent<PP_LightWave>().enabled=true;
			weaponCam.GetComponent<PP_RadialBlur>().enabled=true;
			if(shiftTimer>1f)
			{
			weaponCam.GetComponent<PP_LightWave>().enabled=false;
			weaponCam.GetComponent<PP_RadialBlur>().enabled=false;
				//	Debug.Log ("MOVE IT!");
				shiftTimer=0f;
				AdrenalineScript.playerDead=false;
				StartCoroutine ("EnemyBody");
				nearBody=false;
			}
			}
		}
	}

void MoveObject (Transform thisTrans,Vector3 startPos ,Vector3 endPos ,float time) 
	{
    float i = 0f;
    float rate = 1f/time;
    while (i < 1f) {
        i += Time.deltaTime * rate;
        thisTrans.position = Vector3.Lerp(startPos, endPos, i);
		}

        return;
	}
	
	IEnumerator EnemyBody()
	{
		//Debug.Log (enemy);
		randAmbient=Random.Range (0,5);
		//randWeapon=Random.Range (0,5);
		//randWeapon=6;
		if(enemy.name=="MOBOT")
		{
			Debug.Log("MOBOT!!!!");
			enemyType=1;
			//Debug.Log ("OK");
			ShootScript.weapon=5;
			sniper.SetActive(false);
			laser.SetActive(true);
			shotgun.SetActive (false);
			revolver.SetActive (false);
			dualrevolver.SetActive (false);	
			katana.SetActive (false);
			((DepthOfFieldScatter)(weaponCam.GetComponent<DepthOfFieldScatter>())).enabled=false;
		}
		
		if(enemy.name=="SniperKyle")
		{
			enemyType=4;
			ShootScript.weapon=7;
			sniper.SetActive(true);
			revolver.SetActive (false);
			dualrevolver.SetActive (false);
			laser.SetActive(false);
			shotgun.SetActive (false);
			katana.SetActive (false);
			
			((DepthOfFieldScatter)(weaponCam.GetComponent<DepthOfFieldScatter>())).enabled=true;
		}
		
		if(enemy.name=="GunKyle")
		{
			enemyType=3;
			randWeapon=Random.Range (0,3);
			if(randWeapon==0)
			{
			ShootScript.weapon=1;
			sniper.SetActive(false);
			revolver.SetActive (true);
			dualrevolver.SetActive (true);
			laser.SetActive(false);
			shotgun.SetActive (false);
			katana.SetActive (false);
				
			((DepthOfFieldScatter)(weaponCam.GetComponent<DepthOfFieldScatter>())).enabled=false;
		}
			if(randWeapon==1)
		{
			ShootScript.weapon=2;
			sniper.SetActive(false);
			revolver.SetActive (true);
			dualrevolver.SetActive (false);
			laser.SetActive(false);
			shotgun.SetActive (false);
			katana.SetActive (false);
		}
			if(randWeapon==2)
		{
			ShootScript.weapon=3;
			sniper.SetActive(false);
			dualrevolver.SetActive (true);
			revolver.SetActive (false);
			laser.SetActive(false);
			shotgun.SetActive (false);
			katana.SetActive (false);
		}
		}
		
		if(enemy.name=="SwordKyle")
		{
			enemyType=2;
			ShootScript.weapon=6;
			sniper.SetActive(false);
			dualrevolver.SetActive (false);
			revolver.SetActive (false);
			laser.SetActive(false);
			shotgun.SetActive (false);
			katana.SetActive (true);
			
			((DepthOfFieldScatter)(weaponCam.GetComponent<DepthOfFieldScatter>())).enabled=false;
			
		}
		
		
		
		
		
		if(randAmbient==0)
		{
			dirLight.color=Color.magenta;
			fpsCam.GetComponent<GlobalFog>().globalFogColor=Color.blue;
		}
			if(randAmbient==1)
		{
			dirLight.color=Color.blue;
			fpsCam.GetComponent<GlobalFog>().globalFogColor=Color.green;
		}
			if(randAmbient==2)
		{
			dirLight.color=Color.green;
			fpsCam.GetComponent<GlobalFog>().globalFogColor=Color.red;
		}
			if(randAmbient==3)
		{
			dirLight.color=Color.red;
			fpsCam.GetComponent<GlobalFog>().globalFogColor=Color.yellow;
		}
		if(randAmbient==4)
		{
			dirLight.color=Color.yellow;
			fpsCam.GetComponent<GlobalFog>().globalFogColor=Color.magenta;
		}
		
				shifting=false;
				enemyCount--;
				AdrenalineScript.anotherKill=true;
				AdrenalineScript.killStreak++;
				Destroy (enemy.transform.parent.gameObject);
		
		yield return null;
	}

}
