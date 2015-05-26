using UnityEngine;
using System.Collections;

public class WorldBoundController : MonoBehaviour {

	PlayerController player; 

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			//!< Kill Player 
			//!< Reset Player to Spawn 
			player.respawn();
		}
		
	}

}
