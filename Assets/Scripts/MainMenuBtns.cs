using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]

public class MainMenuBtns : MonoBehaviour {
	
	public string levelToLoad;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public AudioClip beep;
	
	public bool quitButton = false;
	
	void OnMouseEnter(){
 		guiTexture.texture = rollOverTexture; 
	}
	
	void OnMouseExit(){
		guiTexture.texture = normalTexture;	
	}
	
	IEnumerator OnMouseUp(){

 		audio.PlayOneShot(beep);
 		yield return new WaitForSeconds(0.35f);
		
		if(quitButton){
			Application.Quit();
			// Debug.Log("This part works!");
		}
		else {
			Application.LoadLevel(levelToLoad);
		}
 		
	}
	
	void Start(){}

}
