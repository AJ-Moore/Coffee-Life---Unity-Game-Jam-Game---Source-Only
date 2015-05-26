﻿using UnityEngine;
using System.Collections;

public class LevelGoal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			//!< get the game director 
			Director director = GameObject.FindObjectOfType<Director>(); 
			director.startMenu = "ScoreMenu"; 
			Application.LoadLevel ("MainMenu");


		}
		
	}

}
