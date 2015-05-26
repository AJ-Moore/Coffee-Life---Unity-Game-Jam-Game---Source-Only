using UnityEngine;
using System.Collections;



public class Director : MonoBehaviour {

	public AudioSource sfxPlayer; 

	//!< The menu that will be loaded when the main menu scene is loaded. 
	public string startMenu = "MainMenu"; 

	//!< how many eggs etc have been picked up this level.
	public int eggsCollected = 0; 
	public int beansCollected = 0; 

	public int totalEggsCollected = 0; 
	public int totalBeansCollected = 0; 

	//whether the eggs on the current level have been collected. 
	// [0] == level1. //size === num levels 
	public bool[] levelEggCollected; 

	// Use this for initialization
	void Start () {
	
		//!< Make the director persistent between scenes 
		GameObject.DontDestroyOnLoad (this.gameObject);

		for (int i = 0; i < this.levelEggCollected.Length; i++) {
			this.levelEggCollected[i] = false; 
		}
		                             
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
