using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class ScoreMenu : MonoBehaviour {
	
	public GameObject beansText; 
	public GameObject eggsText; 


	// Use this for initialization
	void Start () {

		//!< get the games director 
		Director director = GameObject.FindObjectOfType<Director> (); 


		Text beans = beansText.GetComponentInChildren<Text> (); 
		Text eggs = eggsText.GetComponentInChildren<Text> (); 


		//!< Check whether the eggs have been collected. 
		eggs.text = director.eggsCollected.ToString(); 
		beans.text = director.beansCollected.ToString (); 

		director.totalBeansCollected += director.beansCollected; 

		//reset ready for next level 
		director.eggsCollected = 0; 
		director.beansCollected = 0;
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
