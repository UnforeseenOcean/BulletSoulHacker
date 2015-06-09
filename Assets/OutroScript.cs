using UnityEngine;
using System.Collections;

public class OutroScript : MonoBehaviour {
	
	public GameObject upskirtMia;
	public GUIText upskirtText;
	
	public GameObject carl;
	public GUIText carlText;
	
	public GameObject carlFinal;	
	public GUIText creditText;
	
	public GameObject outroObj;
	private float timer=0f;

	// Use this for initialization
	void OnEnable() {
		
		carlFinal.SetActive (false);
		carl.SetActive (false);
		carlText.enabled=false;
		creditText.enabled=false;
		
		outroObj.SetActive (true);
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		timer+=Time.deltaTime;
		
		if(timer<6f)
		{
			upskirtMia.SetActive(true);
			upskirtText.enabled=true;
			upskirtText.text="I had chosen the wrong contract";
		}
		
		if(timer>6f && timer<11f)
		{
			upskirtText.text="Their dirty secrets still walked with me";
		}
		
		if(timer>11f && timer<17f)
		{
			upskirtText.enabled=false;
			carlText.enabled=true;
			carl.SetActive (true);
			upskirtMia.SetActive (false);
			carlText.text="I was safe for now";
		}
		if(timer>17f && timer<22f)
		{

			carlText.text="Trapped in another \n vessel";
		}
		
		if(timer>22f && timer<27f)
		{

			carlText.text="Silently biding my time";
		}
		
		if(timer>27f && timer<35f)
		{
			
			carlText.enabled=false;
			creditText.enabled=true;
			carl.SetActive (false);
			carlFinal.SetActive (true);
			creditText.text="Waiting for the light to fade";

		}
		
		if(timer>36f && timer<42f)
		{
			creditText.text="Concept & Developed by \n  Ansh";
		}
		
		if(timer>42f && timer<48f)
		{
			creditText.text="Music by: \n Sumanth \n Ansh";
		}
		
		if(timer>48f && timer<52f)
		{
			creditText.text="Thank you for playing!";
		}
		
		if(timer>52f)
		{
			Application.Quit ();
		}
	
	}
}
