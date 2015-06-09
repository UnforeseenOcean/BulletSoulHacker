using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	
	public GameObject agony;
	public GameObject dead;
	//public AudioListener levelMusic;
	public GameObject levelMusic;
	public GameObject cry;
	public GameObject gunShots;
	public GameObject dualgunShots;
	
	public GameObject intro;
	public GameObject outro;
	
	public GameObject vortex;
	
	public static int nowPlaying=0;
	private bool change=true;
	public PlaylistController clip;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable()
	{
		BuildingGenerator.soundManager=gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(SoulTransport.shifting)
		{
			nowPlaying=7;
			
		}
		
		//Debug.Log (nowPlaying);
		
		if(BuildingGenerator.intro)
		{
			nowPlaying=5;
		}
		else if(BuildingGenerator.outro)
		{
			nowPlaying=6;
		}
		
		else
		{
		
		if(AdrenalineScript.playerDead || AdrenalineScript.lost)
		{
			nowPlaying=2;
		}
		
		else if(AdrenalineScript.memory)
		{
			nowPlaying=4;
		}
		
		else if(SoulTransport.enemyType==3 || SoulTransport.enemyType==4)
		{
			nowPlaying=1;
		}
		else
		{
			nowPlaying=3;
		}
		}
		
		if(nowPlaying==1)
		{
	
			agony.SetActive (true);
			//levelMusic.enabled=true;
			//levelMusic.SetActive(true);
			if(change)
			{
			MasterAudio.ResumePlaylist();
			change=false;
			}
			gunShots.SetActive(true);
			dualgunShots.SetActive(true);
			
			dead.SetActive (false);
			intro.SetActive (false);
			outro.SetActive (false);
			vortex.SetActive (false);
			cry.SetActive(false);
			
		}
		if(nowPlaying==2)
		{
			dead.SetActive (true);
			
			cry.SetActive(false);
			agony.SetActive(false);
			//levelMusic.enabled=false;
			MasterAudio.PausePlaylist();
			//levelMusic.SetActive (false);
			intro.SetActive (false);
			outro.SetActive (false);
			gunShots.SetActive(false);
			dualgunShots.SetActive(true);
			vortex.SetActive (false);
			
			change=true;
		}
		
		if(nowPlaying==3)
		{
		//	levelMusic.enabled=true;
			if(change)
			{
			MasterAudio.ResumePlaylist();
			change=false;
			}
			gunShots.SetActive(true);
			dualgunShots.SetActive(true);
			agony.SetActive (false);
			intro.SetActive (false);
			outro.SetActive (false);
			dead.SetActive (false);
			cry.SetActive(false);
			vortex.SetActive (false);
		}
		
		if(nowPlaying==4)
		{

			cry.SetActive(true);
			
			dead.SetActive (false);		
			agony.SetActive(false);
			//levelMusic.enabled=false;
			MasterAudio.PausePlaylist();
			intro.SetActive (false);
			outro.SetActive (false);
			gunShots.SetActive(false);
			dualgunShots.SetActive (false);
			vortex.SetActive (false);
			
			change=true;
		}
		
		if(nowPlaying==5)
		{
			intro.SetActive (true);
			
			outro.SetActive (false);
			cry.SetActive(false);
			dead.SetActive (false);		
			agony.SetActive(false);
			MasterAudio.PausePlaylist();
			//levelMusic.SetActive (false);
		//	levelMusic.enabled=false;
			gunShots.SetActive(false);
			dualgunShots.SetActive (false);
			vortex.SetActive (false);
			
			change=true;
		}
		if(nowPlaying==6)
		{
			outro.SetActive (true);
			
			intro.SetActive (false);
			cry.SetActive(false);
			dead.SetActive (false);		
			agony.SetActive(false);
			MasterAudio.PausePlaylist();
			//levelMusic.SetActive (false);
			//levelMusic.enabled=false;
			gunShots.SetActive(false);
			dualgunShots.SetActive (false);
			vortex.SetActive (false);
			
			change=true;
		}
		
		if(nowPlaying==7)
		{
			if(change)
			{
			MasterAudio.ResumePlaylist();
			change=false;
			}
			vortex.SetActive (true);
			
			gunShots.SetActive(false);
			outro.SetActive (false);
			intro.SetActive (false);
			cry.SetActive(false);
			dead.SetActive (false);		
			agony.SetActive(false);
			MasterAudio.PausePlaylist();
			//levelMusic.SetActive (false);
			//levelMusic.enabled=false;
			dualgunShots.SetActive (false);

		}
	
	}
}
