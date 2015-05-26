using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D obj) {
		if (obj.gameObject.tag == "Player") {
			PlayerController player = GameObject.FindObjectOfType<PlayerController>(); 
			player.respawn();
		}
	}
}
