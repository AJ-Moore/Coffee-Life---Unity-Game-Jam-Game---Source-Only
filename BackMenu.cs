using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackMenu : MonoBehaviour {

	public GameObject beansCount; 
	public GameObject eggsCount; 

	Text eggsTotal;
	Text beansTotal;
	Director director;
	
	// Use this for initialization
	void Start () {
		//!< get the games director 
		director = GameObject.FindObjectOfType<Director> (); 

		eggsTotal = eggsCount.GetComponentInChildren<Text> (); 
		beansTotal = beansCount.GetComponentInChildren<Text> (); 

		eggsTotal.text = director.totalEggsCollected.ToString(); 
		beansTotal.text = director.totalBeansCollected.ToString();

	}
	
	// Update is called once per frame
	void Update () {
	
		//!< If the score has changed 
		if (this.eggsTotal.text != director.totalEggsCollected.ToString () ||
		    this.beansTotal.text != director.totalBeansCollected.ToString ()) {

			eggsTotal.text = director.totalEggsCollected.ToString(); 
			beansTotal.text = director.totalBeansCollected.ToString();
			
		}
	}
}
