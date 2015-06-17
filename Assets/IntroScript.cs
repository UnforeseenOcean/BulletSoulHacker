using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {
	
	public GameObject narcissistCam;
	public GameObject narcText;
	public GUIText gunText;
	
	public GameObject sideMia;
	public GUIText sideText;
	
	public GameObject frontMia;
	public GUIText frontText;
	
	public GameObject windowMia;
	public GUIText windowText;
	
	public GameObject carlCam;
	
	public GameObject serverCam;
	public GUIText serverText;
	
	private float timer=0f;
	
	private float lerpTimer=0f;
	
	public GameObject introObj;
	

	// Use this for initialization
	void OnEnable () 
	{
		narcissistCam.SetActive (true);
		sideMia.SetActive (false);
		frontMia.SetActive (false);		
		windowMia.SetActive (false);
		carlCam.SetActive (false);
		serverCam.SetActive (false);
		frontText.enabled=false;
		sideText.enabled=false;
		windowText.enabled=false;
		serverText.enabled=false;
		gunText.enabled=false;
		
		introObj.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
		timer+=Time.deltaTime;
		Debug.Log (timer);

		if (Input.GetKeyDown (KeyCode.Space))
			timer = 50f;
		
		if(timer<3f)
		{
			narcissistCam.SetActive (true);
		}
		
		if(timer>3f && timer <7f)
		{
			narcissistCam.SetActive (false);
			narcText.SetActive (false);
			frontText.enabled=true;
			frontText.text="It was another night in the void";
			frontMia.SetActive(true);
		}
		
		if(timer>7f && timer<10f)
		{
			frontText.text="Doing just another job";
		}
		
		if(timer>10f && timer<13f)
		{
			frontText.text="a simple infiltration";
		}
		if(timer>13f && timer<17f)
		{
			frontText.enabled=false;
			sideText.enabled=true;
			frontMia.SetActive (false);
			sideMia.SetActive (true);
			sideText.text="a question weighed heavily \n on my mind";
		}
		
		if(timer>17f && timer<22f)
		{
			sideText.enabled=false;
			sideMia.SetActive (false);
			serverCam.SetActive (true);
			serverText.enabled=true;
			serverText.text="even as i reached the server room, \n my mind was distracted";
		}
		
		if(timer>22f && timer<28f)
		{
			serverCam.SetActive (false);
			serverText.enabled=false;
			narcissistCam.SetActive (true);
			narcissistCam.GetComponent<Camera>().fieldOfView=20;
			gunText.enabled=true;
			gunText.text="whose body was i in, \n whose memories did these belong to?";
		}
		if(timer>28f && timer<34f)
		{
			gunText.text="if there was a line, \n it had long since disappeared";
		}
		
		if(timer>34f && timer<40f)
		{
			gunText.enabled=false;
			narcissistCam.SetActive (false);
			windowMia.SetActive (true);
			windowText.enabled=true;
			windowText.text="with data in my soul and memories of many in my head, \n i looked outside";
		}
		
		if(timer>40f && timer<44f)
		{
			lerpTimer+=Time.deltaTime;
			windowMia.GetComponent<PP_CrossHatch>().lineColor=Color.Lerp (Color.blue,Color.red,lerpTimer);
			if(lerpTimer>=1f)
			{
				lerpTimer=0f;
			}
			//windowMia.GetComponent<PP_CrossHatch>().lineColor=Color.red;
			windowText.text="ringing alarms \n told me just one thing";
		}
		
		if(timer>44f && timer<50f)
		{
			windowText.color=Color.blue;
			windowText.text="the night had only begun";
		}
		if(timer>50f)
		{
			narcissistCam.SetActive (true);
			sideMia.SetActive (false);
			serverCam.SetActive (false);
			frontMia.SetActive(false);
			windowMia.SetActive (true);
			
			AdrenalineScript.mainMenu=true;
			this.enabled=false;
		}
	
	}
}
