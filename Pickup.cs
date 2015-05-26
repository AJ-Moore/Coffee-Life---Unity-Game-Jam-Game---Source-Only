using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	
	[Range(1,179)]
	public float rotationAmount = 33.0f; 
	
	public float rotationSpeed = 1.0f;
	
	AudioSource audio; 
	public AudioClip pickUpSound; 
	
	//!< toggles between direction 
	bool direction = true; 
	
	//!< The game director
	Director director;
	
	// Use this for initialization
	void Start () {
		//!< get the game director 
		this.director = GameObject.FindObjectOfType<Director> (); 
		
		this.audio = this.GetComponentInChildren<AudioSource>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
		float rotation = this.transform.eulerAngles.z - 180; 
		
		if (rotation > 0) {
			rotation = 180-rotation;
		}
		
		if (direction) {
			this.transform.Rotate(new Vector3(0,0,this.rotationSpeed * Time.deltaTime)); 
			if (rotation > -180 + this.rotationAmount && rotation < 0){
				direction = !direction;
			}
			
		} else {
			float rotAmount = 360 - (this.rotationSpeed * Time.deltaTime);
			this.transform.Rotate(new Vector3(0,0,rotAmount)); 
			if (rotation > this.rotationAmount){
				direction = !direction;
			}
		}
		
		
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			
			//!< Add one to the egg score - Player doesn't have to reach the end of the level to count 
			if ( this.director != null){
				this.director.beansCollected++; 
			}
			
			//!< Play a sound when the egg is collected... 
			this.audio.PlayOneShot(this.pickUpSound); 
			
			//Disable the collider. 
			Collider2D collider = this.GetComponentInChildren<CircleCollider2D> (); 
			collider.enabled = false; 
			//Disable the egg.
			this.disableEgg(); 
			//this.gameObject.SetActive(false); 
			
			
			
		}
		
	}
	
	//!< Prevents the egg from being rendered or responding to collision. 
	void disableEgg(){
		Renderer renderer = this.GetComponentInChildren<Renderer> (); 
		renderer.enabled = false; 
		
	}
	
}
