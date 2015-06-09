using UnityEngine;
using System.Collections;

public class AdrenalineScript : MonoBehaviour {
	
	
	public static int killStreak=0;
	public static float timeLeft=55f;
	public static bool timeGained=false;
	public UILabel timeCounter;
	public UILabel adrenalineCounter;
	public UILabel time;
	public UILabel adrenaline;
	public UILabel human;
	public UILabel AI;
	public UILabel flyFreely;
	public UISlider life;
	public UISlider rivalLife;
	public UILabel lifePlus;
	public UILabel timePlus;
	public GameObject lifeObj;
	public GameObject rivalObj;
	public static float lifeCount=100f;
	public static bool lifeGained=false;
	private int randMemory=0;
	public UILabel gameOver;
	
	public static bool mainMenu=false;
	
	public static bool lost=false;
	
	private float penaltyTimer=0f;
	
	private int randGood=0;
	private int randBad=0;
	
	public static int acqNegative=0;
	public static int acqPositive=0;
	
	//Human Good
	public UILabel resilient;
	public UILabel sharpshooter;
	
	//Humans Bad
	public UILabel weakMind;
	public UILabel openWound;
	
	
	//AI Good
	public UILabel fasterMovement;
	public UILabel nodeHack;
	
	
	//AI Bad
	public UILabel corruptAI;
	public UILabel badSector;
	
	
	public UILabel node;
	public UILabel nodeCount;
	
	public static bool playerDead=false;
	public UILabel searchBody;
	public GameObject deadCam;
	public GameObject aliveCam;
	public GameObject weaponCam;
	
	public GameObject mainPlayer;
	
	public GameObject dogCam;
	public GameObject photoCam;
	public GameObject gfCam;
	public GameObject selfCam;
	public GameObject storyCam;
	
	public GameObject storyObj;
	public GameObject expObj;
	public GameObject arcadeObj;
	
	public UIButton storyMode;
	public UIButton expMode;
	public UIButton arcadeMode;
	
	public GameObject uiObj;
	public GUIText titleText;
	
	private float memoryFlash=0f;
	public static bool memory=false;
	
	public static bool anotherKill=true;
	private float streakReset=0f;
	public GameObject introObj;
	public GameObject gameOverCam;
	private Vector3 resetPos=new Vector3(64.5f,222f,173f);
	
	
	// Use this for initialization
	void Start () {
		
		Time.timeScale=1f;
		deadCam.SetActive (false);
		lifePlus.enabled=false;
		timePlus.enabled=false;
		dogCam.GetComponent<Camera>().enabled=false;
		storyCam.GetComponent<Camera>().enabled=false;
		selfCam.GetComponent<Camera>().enabled=false;
		gfCam.GetComponent<Camera>().enabled=false;
		photoCam.GetComponent<Camera>().enabled=false;
		
		gameOver.enabled=false;
		gameOverCam.SetActive (false);
		
		storyMode.enabled=false;
		expMode.enabled=false;
		arcadeMode.enabled=false;
		expObj.SetActive (false);
		storyObj.SetActive(false);
		arcadeObj.SetActive (false);
		titleText.enabled=false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log (lost);
		
		//Debug.Log (playerDead);
		if(BuildingGenerator.intro || BuildingGenerator.outro || mainMenu || lost)
		{
			if(mainMenu)
		{
			uiObj.SetActive (true);
			Screen.lockCursor=false;
			storyMode.gameObject.SetActive (true);
			expMode.gameObject.SetActive (true);
			arcadeMode.gameObject.SetActive (true);
			titleText.enabled=true;
			
			lifeObj.SetActive (false);
				rivalObj.SetActive (false);
				adrenaline.enabled=false;
				time.enabled=false;
				timeCounter.enabled=false;
				adrenalineCounter.enabled=false;
				AI.enabled=false;
				human.enabled=false;
				corruptAI.enabled=false;
				searchBody.enabled=false;
				gameOver.enabled=false;
				openWound.enabled=false;
				weakMind.enabled=false;
				badSector.enabled=false;	
				resilient.enabled=false;
				fasterMovement.enabled=false;
				nodeHack.enabled=false;
				sharpshooter.enabled=false;
				flyFreely.enabled=false;
				node.enabled=false;
				nodeCount.enabled=false;
			BuildingGenerator.intro=false;
			
			
			if(BuildingGenerator.mode==1)
			{
				introObj.SetActive (false);
				mainPlayer.SetActive (true);
				storyObj.SetActive (true);
					storyMode.gameObject.SetActive(false);
					expMode.gameObject.SetActive (false);
					timeCounter.enabled=true;
					adrenalineCounter.enabled=true;
					arcadeMode.gameObject.SetActive (false);
					titleText.enabled=false;
					Screen.lockCursor=true;
					mainMenu=false;
				
				
			}
			if(BuildingGenerator.mode==2)
			{
				introObj.SetActive (false);
				mainPlayer.SetActive (true);
				arcadeObj.SetActive (true);
					storyMode.gameObject.SetActive(false);
					expMode.gameObject.SetActive (false);
					timeCounter.enabled=true;
					adrenalineCounter.enabled=true;
					arcadeMode.gameObject.SetActive (false);
					titleText.enabled=false;
					Screen.lockCursor=true;
					mainMenu=false;
			}
			if(BuildingGenerator.mode==3)
			{
				introObj.SetActive (false);
				mainPlayer.SetActive (true);
			 	expObj.SetActive (true);
					storyMode.gameObject.SetActive(false);
					expMode.gameObject.SetActive (false);
					arcadeMode.gameObject.SetActive (false);
					timeCounter.enabled=true;
					adrenalineCounter.enabled=true;
					titleText.enabled=false;
					Screen.lockCursor=true;
					mainMenu=false;
			}
		
		}

			
			if(lost)
			{
				SoundScript.nowPlaying=2;
				
				lifeObj.SetActive (false);
				rivalObj.SetActive(false);
				adrenaline.enabled=false;
				time.enabled=false;
				timeCounter.enabled=false;
				adrenalineCounter.enabled=false;
				AI.enabled=false;
				human.enabled=false;
				corruptAI.enabled=false;
				openWound.enabled=false;
				weakMind.enabled=false;
				badSector.enabled=false;	
				resilient.enabled=false;
				fasterMovement.enabled=false;
				nodeHack.enabled=false;
				sharpshooter.enabled=false;
				flyFreely.enabled=false;
				node.enabled=false;
				nodeCount.enabled=false;
				
				
				mainPlayer.GetComponent<vp_FPInput>().enabled=false;
				mainPlayer.transform.position=resetPos;
				mainPlayer.GetComponent<vp_FPController>().enabled=false;
				gameOver.enabled=true;
				gameOverCam.SetActive (true);
				aliveCam.SetActive (false);
				
				if(Input.GetKeyDown (KeyCode.R))
				{
					lifeObj.SetActive (true);
					SoulTransport.enemyCount=0;
					lifeCount=100f;
					timeLeft=40f;
					killStreak=0;
					BuildingGenerator.nodeObtained=0;
					BuildingGenerator.nodeOpportunity=0;
					CheckpointGenerator.checkpointCount=0;
					adrenaline.enabled=true;
					time.enabled=true;
					timeCounter.enabled=true;
					adrenalineCounter.enabled=true;
					gameOver.enabled=false;
					gameOverCam.SetActive (false);
					mainPlayer.GetComponent<vp_FPInput>().enabled=true;
				mainPlayer.GetComponent<vp_FPController>().enabled=true;
					aliveCam.SetActive (true);
					lost=false;
				}
			}
			else
			{
				gameOver.enabled=false;
				gameOverCam.SetActive (false);
			}
		}
		else
		{
		
		if(playerDead==false)
		{
				if(!SoulTransport.onGround)
				{
			deadCam.SetActive (false);
			aliveCam.SetActive (true);
				}
				searchBody.enabled=false;
		}
			else
			{
				searchBody.enabled=true;
			}
		
		if(!playerDead)
		{
			if(!memory || SoulTransport.enemyType!=3 || SoulTransport.enemyType!=4)
			{
			 	SoundScript.nowPlaying=3;
			}
			
		if(lifeGained)
			{
				StartCoroutine ("LifeGain");
			}
			
		if(timeGained)
			{
				StartCoroutine ("TimeGain");
			}	
			
			
		if(killStreak!=0 && killStreak<10)
		Time.timeScale=1f+(1f*((killStreak-1)/4f));
			
		if(!anotherKill)
			{
				if(SoulTransport.enemyType==3 || SoulTransport.enemyType==4)
				{
				memoryFlash+=Time.deltaTime;
				if(memoryFlash>12f)
				{
						memory=true;
						SoundScript.nowPlaying=4;
						
					StartCoroutine ("MemoryFlash");
					memoryFlash=0f;
				}
				}
				if(killStreak>0)
				{
				streakReset+=Time.deltaTime;
				if(streakReset>15f)
				{
					killStreak--;
					streakReset=0f;
				}
				}
			}
		
		if(acqNegative==4)
		{
		penaltyTimer+=Time.deltaTime;
		
		if(penaltyTimer>2f)
		{
			lifeCount-=5f;
			penaltyTimer=0f;
		}
		}
		
		
		if(timeLeft>0f)
		timeLeft-=Time.deltaTime;
		else
		{
			timeLeft=0f;
			lost=true;
		}
		if(BuildingGenerator.initialJump)
		{
			//Debug.Log ("YO!!");
			adrenaline.enabled=true;
			time.enabled=true;
			lifeObj.SetActive(true);
			node.enabled=true;
			nodeCount.enabled=true;
					
			nodeCount.text=BuildingGenerator.nodeObtained.ToString()+"\n out of \n"+BuildingGenerator.nodeOpportunity;
			
			if(RivalScript.rivalAlive)
				{
					Debug.Log ("RIVAL BAR");
					rivalObj.SetActive (true);
					rivalLife.sliderValue=RivalScript.life/30f;
				}
				
		if(killStreak<10)
		adrenalineCounter.text="x"+killStreak.ToString();
		else
		{
			adrenalineCounter.text="MAX";
		}
		timeCounter.text=timeLeft.ToString("F2");
		life.enabled=true;
			if(lifeCount>0f)
			{
				life.sliderValue=lifeCount/100f;
			}
			else
			{
				playerDead=true;
				SoundScript.nowPlaying=2;
					if(!SoulTransport.onGround)
				{
				aliveCam.SetActive(false);
				deadCam.SetActive(true);
						}
				searchBody.enabled=true;
				
				adrenaline.enabled=false;
				time.enabled=false;
				timeCounter.enabled=false;
				adrenalineCounter.enabled=false;
				AI.enabled=false;
				human.enabled=false;
				corruptAI.enabled=false;
				openWound.enabled=false;
				weakMind.enabled=false;
				badSector.enabled=false;	
				resilient.enabled=false;
				fasterMovement.enabled=false;
				nodeHack.enabled=false;
				sharpshooter.enabled=false;
				flyFreely.enabled=false;
				node.enabled=false;
				nodeCount.enabled=false;
				//Time.timeScale=0.1f;
			}
			
			
			if(SoulTransport.enemyType==1 || SoulTransport.enemyType==2) //AI
			{
				if(anotherKill)
				{
				randGood=Random.Range (0,2);
				randBad=Random.Range (0,2);
				AI.enabled=true;
				human.enabled=false;
				
				if(randGood==0)
				{
					resilient.enabled=false;
					sharpshooter.enabled=false;
					nodeHack.enabled=false;
					
					fasterMovement.enabled=true;
					acqPositive=1;
				}
				else if(randGood==1)
				{
					resilient.enabled=false;
					sharpshooter.enabled=false;
					fasterMovement.enabled=false;
					
					nodeHack.enabled=true;
				}
				
				if(randBad==0)
				{
					badSector.enabled=false;
					weakMind.enabled=false;
					openWound.enabled=false;
					
					corruptAI.enabled=true;
					acqNegative=1;
				}
				
				else if(randBad==1)
				{
					corruptAI.enabled=false;
					weakMind.enabled=false;
					openWound.enabled=false;
					
					badSector.enabled=true;
					acqNegative=2;
				}
					anotherKill=false;
				}
			}
			else if(SoulTransport.enemyType==3 || SoulTransport.enemyType==4) // Humans
			{
				SoundScript.nowPlaying=1;
					
				if(anotherKill)
				{
				randGood=Random.Range (0,2);
				randBad=Random.Range (0,2);
						
				lifeCount+=10f;
				
				AI.enabled=false;
				human.enabled=true;
				
				if(randGood==0)
				{
					resilient.enabled=false;
					sharpshooter.enabled=false;
					nodeHack.enabled=false;
					
					resilient.enabled=true;
					acqPositive=3;
					
				}
				else if(randGood==1)
				{
					resilient.enabled=false;
					fasterMovement.enabled=false;
					nodeHack.enabled=false;
					
					sharpshooter.enabled=true;
					acqPositive=4;
				}
				
				if(randBad==0)
				{
					corruptAI.enabled=false;
					badSector.enabled=false;
					openWound.enabled=false;
					
					weakMind.enabled=true;
					acqNegative=3;
					
				}
				else if(randBad==1)
				{
					corruptAI.enabled=false;
					weakMind.enabled=false;
					badSector.enabled=false;
					
					openWound.enabled=true;
					acqNegative=4;
				}
					anotherKill=false;
				}
			}
			
			if(ShootScript.weapon==6)
			{
				flyFreely.enabled=true;
			}
			else
			{
				flyFreely.enabled=false;
			}
		}
		else
		{
			
			adrenaline.enabled=false;
			time.enabled=false;
			
			AI.enabled=false;
			human.enabled=false;
			
			node.enabled=false;
			nodeCount.enabled=false;		
					
			corruptAI.enabled=false;
			openWound.enabled=false;
			weakMind.enabled=false;
			badSector.enabled=false;
			
			searchBody.enabled=false;
			resilient.enabled=false;
			fasterMovement.enabled=false;
			nodeHack.enabled=false;
			sharpshooter.enabled=false;
			
			flyFreely.enabled=false;
					
			storyMode.enabled=false;
			expMode.enabled=false;
			arcadeMode.enabled=false;
			titleText.enabled=false;
			
			lifeObj.SetActive(false);
			rivalObj.SetActive (false);
			adrenalineCounter.text="";
			timeCounter.text="";
		}
		}
		
		else
		{
			if(SoulTransport.nearBody)
			{
					if(!SoulTransport.onGround)
				{
				deadCam.SetActive (false);
				aliveCam.SetActive (true);
					}
				time.enabled=true;
				timeCounter.enabled=true;
				adrenaline.enabled=true;
				adrenalineCounter.enabled=true;
			}
			else
			{
			lifeObj.SetActive(false);
			rivalObj.SetActive (false);
			searchBody.enabled=true;
			}
		}
		}
		
	}
	
	IEnumerator LifeGain()
	{
		lifePlus.enabled=true;
		yield return new WaitForSeconds(3f);
		lifePlus.enabled=false;
		lifeGained=false;
		yield return null;
		
	}
	
	IEnumerator TimeGain()
	{
		timePlus.enabled=true;
		yield return new WaitForSeconds(3f);
		timePlus.enabled=false;
		timeGained=false;
		yield return null;
		
	}
	IEnumerator MemoryFlash()
	{
		randMemory=Random.Range (0,5);
		if(randMemory==0)
		{
			aliveCam.GetComponent<Camera>().enabled=false;
			weaponCam.GetComponent<Camera>().enabled=false;
			dogCam.GetComponent<Camera>().enabled=true;
			yield return new WaitForSeconds(0.8f);
			dogCam.GetComponent<Camera>().enabled=false;
			aliveCam.GetComponent<Camera>().enabled=true;
			weaponCam.GetComponent<Camera>().enabled=true;
			
		}
		else if(randMemory==1)
		{
			aliveCam.GetComponent<Camera>().enabled=false;
			weaponCam.GetComponent<Camera>().enabled=false;
			photoCam.GetComponent<Camera>().enabled=true;
			yield return new WaitForSeconds(0.8f);
			photoCam.GetComponent<Camera>().enabled=false;
			aliveCam.GetComponent<Camera>().enabled=true;
			weaponCam.GetComponent<Camera>().enabled=true;
			
			
		}
		else if(randMemory==2)
		{
			aliveCam.GetComponent<Camera>().enabled=false;
			weaponCam.GetComponent<Camera>().enabled=false;
			gfCam.GetComponent<Camera>().enabled=true;
			yield return new WaitForSeconds(0.8f);
			gfCam.GetComponent<Camera>().enabled=false;
			aliveCam.GetComponent<Camera>().enabled=true;
			weaponCam.GetComponent<Camera>().enabled=true;
			
		}
		else if(randMemory==3)
		{
			aliveCam.GetComponent<Camera>().enabled=false;
			weaponCam.GetComponent<Camera>().enabled=false;
			selfCam.GetComponent<Camera>().enabled=true;
			yield return new WaitForSeconds(0.8f);
			selfCam.GetComponent<Camera>().enabled=false;
			aliveCam.GetComponent<Camera>().enabled=true;
			weaponCam.GetComponent<Camera>().enabled=true;
			
		}
		else
		{
			aliveCam.GetComponent<Camera>().enabled=false;
			weaponCam.GetComponent<Camera>().enabled=false;
			storyCam.GetComponent<Camera>().enabled=true;
			yield return new WaitForSeconds(0.8f);
			storyCam.GetComponent<Camera>().enabled=false;
			aliveCam.GetComponent<Camera>().enabled=true;
			weaponCam.GetComponent<Camera>().enabled=true;
			
		}
		memoryFlash=0f;
		memory=false;
		yield return null;
	}
	
}
