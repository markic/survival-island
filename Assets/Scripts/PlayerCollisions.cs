using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {
	
	private bool doorIsOpen = false;
	private float doorTimer = 0.0f;
	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorCloseSound;
	private GameObject currentDoor;
	
	void DoorAction(AudioClip aClip, bool checkOpen, string animName, GameObject door){
		doorIsOpen = checkOpen;
		door.transform.parent.animation.Play(animName);
		door.audio.PlayOneShot(aClip);
		
	}	
	
	void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject.tag == "cabinDoor" && doorIsOpen == false){
			//currentDoor = hit.gameObject;
			//DoorAction(doorOpenSound, true, "dooropen",currentDoor);
		}
	}
	

	// Update is called once per frame
	void Update () {
		if(doorIsOpen){
			doorTimer += Time.deltaTime;
			
			if(doorTimer > doorOpenTime){
				doorTimer = 0.0f;
				//DoorAction(doorCloseSound, false, "doorshut", currentDoor);
			}
			
		}
	}
}
