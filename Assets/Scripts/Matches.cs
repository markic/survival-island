using UnityEngine;
using System.Collections;

public class Matches : MonoBehaviour {
	
	private bool showMessage = true;
	public GUIText textHints;

	void OnTriggerStay(Collider col){
 		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)){
 			col.gameObject.SendMessage("MatchPickup"); 
 			Destroy(gameObject);
 		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(showMessage){
				textHints.SendMessage("ShowHint", "Press E to pick up...");
				showMessage = false;

			}
		}
	
	
	}

}
