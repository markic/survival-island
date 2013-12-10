using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	
	public static int charge = 0;
	
	public AudioClip pickupSound;
	
	public Texture2D [] hudTextures;
	public GUITexture curGUI;
	
	public Texture2D[] meterCharge;
	public Renderer meter;
	
	// Matches
	bool haveMatches = false;
	public GUITexture matchGUI;
	GUITexture matchGUItexture;
	
	// Fire
	ParticleSystem [] particleSystems;
	public GUIText textHints;
	bool fireIsLit = false;
	
	public GameObject winObj;
	
	
	// lightfire on hit with player
	void OnControllerColliderHit(ControllerColliderHit col){
 		if(col.gameObject.name == "campfire"){
 			
			if(haveMatches && !fireIsLit)
			{
 				LightFire(col.gameObject); 
 			
			}
			else if(!haveMatches && !fireIsLit)
			{
 				textHints.SendMessage("ShowHint", "I could use this campfire to signal for help...");
 			}

		}
	}
	
	void LightFire(GameObject obj){
		
		particleSystems = obj.GetComponentsInChildren<ParticleSystem>();
		
		foreach(ParticleSystem i in particleSystems){
			i.Play();
		}
		
		obj.audio.Play();
		
		Destroy(matchGUItexture);
		haveMatches = false;
		fireIsLit = true;
		
		winObj.SendMessage("GameOver");
	
	}
	
	
	// pickup matches
	void MatchPickup(){
 		haveMatches = true;
 		
		AudioSource.PlayClipAtPoint(pickupSound, transform.position);
 		
		GUITexture matchHUD = Instantiate(matchGUI, new Vector3(0.3f, 0.1f, 0),transform.rotation) as GUITexture;
 		matchGUItexture = matchHUD;
	}
	

	// Use this for initialization
	void Start () {
		charge = 0;
	}
	
	void CellPickup(){
		HUDon();
		//LightFire(GameObject.FindGameObjectWithTag("campfire"));
		AudioSource.PlayClipAtPoint(pickupSound, transform.position);
		
		charge++;
		
		curGUI.texture = hudTextures[charge];
		meter.material.mainTexture = meterCharge[charge];
	}
	
	void HUDon(){
		if(!curGUI.enabled) curGUI.enabled = true;

	}
}
