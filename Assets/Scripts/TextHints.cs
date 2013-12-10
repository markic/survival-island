using UnityEngine;
using System.Collections;

public class TextHints : MonoBehaviour {
	
	float timer = 0.0f;
	
	void ShowHint(string message){
 		guiText.text = message;
 		
		if(!guiText.enabled){ guiText.enabled = true; }
 	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(guiText.enabled){
 			timer += Time.deltaTime;
 
 			if(timer >=4){
 				guiText.enabled = false;
 				timer = 0.0f;
 			}
		}
	}
}
