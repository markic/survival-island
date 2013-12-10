using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
	
	public GUITexture loadGUI;
 
	void LoadAnim(){
 		Instantiate(loadGUI);
		
	}

	// Update resolution
	void Start(){ 
 		Rect currentRes = new Rect(-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height); 
 		guiTexture.pixelInset = currentRes; 
	}
}
