using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    private GameObject startMenu = null;
    private GameObject currentMenu = null; 

	//!< Keeps track of all game menus 
	public GameObject[] menus; 


	// Use this for initialization
	void Start () {
	    //!< Set the active menu 
		//!< Get the start menu from the game director 

		Director director = GameObject.FindObjectOfType<Director> (); 

		if (director != null) {
			//Find the menu 
			foreach (GameObject menu in menus){
				if (menu.tag == director.startMenu){
					this.startMenu = menu; 
					break; //break out of loop 
				}
			}
		} else {
			Debug.LogError("No Game Director Was Found"); 
		}
		
        this.currentMenu = startMenu; 
		this.currentMenu.SetActive (true); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SwitchMenu(GameObject Menu)
    {

        if (currentMenu != null)
        {
            currentMenu.SetActive(false);
        }

        currentMenu = Menu;

        currentMenu.SetActive(true); 

    }

	public void ChangeLevel (string LevelName){
		Application.LoadLevel (LevelName); 
	}

	public void QuitGame(){
		Application.Quit ();
	}

}
