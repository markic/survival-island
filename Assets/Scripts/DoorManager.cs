using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {
	
	private bool doorIsOpen = false;
	private float doorTimer = 0.0f;
	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorCloseSound;
	
	void DoorAction(AudioClip aClip, bool checkOpen, string animName){
		doorIsOpen = checkOpen;
		transform.parent.animation.Play(animName);
		audio.PlayOneShot(aClip);
		
	}	
	
	void DoorCheck(){
		if(!doorIsOpen){
			DoorAction(doorOpenSound, true, "dooropen");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if(doorIsOpen){
			doorTimer += Time.deltaTime;
			
			if(doorTimer > doorOpenTime){
				doorTimer = 0.0f;
				DoorAction(doorCloseSound, false, "doorshut");
			}
			
		}
	}
}
