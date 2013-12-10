using UnityEngine;
using System.Collections;

public class TextOnHit : MonoBehaviour {

	public string []messages;	
	private bool msgSent = false;
	public GUIText textHints;

	
	void OnTriggerEnter(Collider col){
 			
		if(col.gameObject.tag == "Player"){
 			
			if(!msgSent){
				StartCoroutine("printMessage");
				msgSent = true;
			}
 			
		}
 	}
	
	// coroutine
	IEnumerator printMessage(){
		textHints.SendMessage("ShowHint", messages[0]);
		yield return new WaitForSeconds(5.0f);
		
		textHints.SendMessage("ShowHint", messages[1]);
		yield return new WaitForSeconds(10.0f);
		
		textHints.SendMessage("ShowHint", messages[2]);
		yield return new WaitForSeconds(10.0f);
		
		textHints.SendMessage("ShowHint", messages[3]);

	}
		

	// Use this for initialization
	void Start () 
	{
		messages = new string[4];

		messages[0] = "What the... ";
		messages[1] = "Where the hell am I?";
		messages[2] = "How much did I drink last night?";
		messages[3] = "All right... current objective... I need to get home...";
	}
	
}
