

using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	private int TimePassed = 0; 
	public int gameStartDelayMS = 1500; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.TimePassed += (int)(Time.deltaTime * 1000); 

		if (this.TimePassed > this.gameStartDelayMS) {
			Application.LoadLevel ("MainMenu");
		}
	}

}

