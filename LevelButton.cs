using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

	//!< Required coffee beans to unlock.
	public int unlockNum = 0; 

	//!< Text object where unlock number is set.
	public GameObject TextObject;

	//!< Designed very quickly
	public GameObject LockObject;

	//!< Holds the button itself so we can disable it if required 
	public GameObject ButtonObj; 

	// Use this for initialization
	void Start () {
	
		//!< Get the game stats from the director 
		//!< theres only one in the scene so we shall use 
		//GameStats stats = GameObject.FindObjectOfType<GameStats> (); 
		Director stats = GameObject.FindObjectOfType<Director> (); 

		//!< Get Buttons child button object
		Button btn = ButtonObj.GetComponentInChildren<Button> (); 
		Text text = TextObject.GetComponentInChildren<Text> ();

		text.text = this.unlockNum.ToString(); 

		//!< Check if the button should be locked or unlocked... 
		if (stats.totalBeansCollected >= this.unlockNum) {
			btn.enabled = true; 
			LockObject.SetActive(false); 
		} else {
			btn.enabled = false; 
			LockObject.SetActive(true);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
