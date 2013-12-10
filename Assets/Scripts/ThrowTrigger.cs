using UnityEngine;
using System.Collections;

public class ThrowTrigger : MonoBehaviour {
	
	public GUITexture crosshair;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider col){
 			if(col.gameObject.tag == "Player"){
 					CoconutThrower.canThrow = true;
					crosshair.enabled = true;
 			}
 	}
	
 	void OnTriggerExit(Collider col){
 		if(col.gameObject.tag == "Player"){
 			CoconutThrower.canThrow	= false;
			crosshair.enabled = false;
 		
		}
 	}
	
}
