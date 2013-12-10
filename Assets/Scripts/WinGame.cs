using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {
	
	public GameObject winSequence;
	public GUITexture fader;
	public AudioClip winClip;
	
	IEnumerator GameOver () {
		
		yield return new WaitForSeconds(8.0f);
		AudioSource.PlayClipAtPoint(winClip, transform.position);
		Instantiate(winSequence);
		
		yield return new WaitForSeconds(8.0f);
		Instantiate(fader);
	
	}

}
