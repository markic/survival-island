using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class MainMenu : MonoBehaviour {
	
	
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect menuArea;
	
	// buttons
	public Rect playButton;
	public Rect instructionsButton;
	public Rect quitButton;
	Rect menuAreaNormalized;
	
	// label
	public Rect info;
	
	public string levelToLoad;
	
	string menuPage = "main";
	public GUITexture fader;
	public static bool showingGUI = true;
	
	IEnumerator ButtonAction(string levelName){
 		audio.PlayOneShot(beep);
 		yield return new WaitForSeconds(0.35f);
 
 		if(levelName != "quit"){
			
			Instantiate(fader);
			showingGUI = false;

			Screen.showCursor = false;
			yield return new WaitForSeconds(5.0f);
			
			Application.LoadLevel(levelName);

			
 		}else{
 			Application.Quit();
 			Debug.Log("Have Quit");
 		}
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin;
		
		if(showingGUI){
			
			GUI.BeginGroup(menuAreaNormalized);

			if(menuPage == "main")
			{
				if(Application.CanStreamedLevelBeLoaded("Island")){
					if(GUI.Button(new Rect(playButton), "Play")){
						StartCoroutine("ButtonAction", levelToLoad);
					}
				}
				else {
					float percentLoaded = Application.GetStreamProgressForLevel(1) * 100;
					GUI.Box(new Rect(playButton), "Loading..." + percentLoaded.ToString("f0") + " % Loaded");
					
				}
		
				if(GUI.Button(new Rect(instructionsButton), "Info")){
					audio.PlayOneShot(beep);
					menuPage = "info";
					
				}
		
				// no quit on web
				if(Application.platform != RuntimePlatform.OSXWebPlayer && Application.platform != RuntimePlatform.WindowsWebPlayer){ 
 					if(GUI.Button(new Rect(quitButton), "Quit")){
 						StartCoroutine("ButtonAction", "quit");
 					}
				}

			}
			else if(menuPage == "info"){
	 			
				GUI.Label(new Rect(info),"You awake on a mysterious island... Find a way to signal for help or face certain doom!\n\nBy: Marin Markic, marinmarkic@mail.com, Belgrade, Serbia.");
				
				if(GUI.Button(new Rect(quitButton), "Back")){
					audio.PlayOneShot(beep);
	 				menuPage = "main";
	 			}

			}

			GUI.EndGroup();
		
		}


	}

	// Use this for initialization
	void Start () {
		menuAreaNormalized = new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
	
	}
	
}
