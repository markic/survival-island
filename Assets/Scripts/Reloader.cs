using UnityEngine;
using System.Collections;

public class Reloader : MonoBehaviour {

	
	void Reload(){
		Screen.showCursor = true;
		MainMenu.showingGUI = true;
 		Application.LoadLevel("Menu");
	}

}
