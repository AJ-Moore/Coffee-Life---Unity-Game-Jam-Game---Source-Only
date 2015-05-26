using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	//!< Delay in MS before platform drops
	public int dropDelayMS = 500; 

	//!< How much time passes before the platform is reset.
	public int resetTimeMS = 2000; 

	//!< the speed at which the platform drops
	public float dropVelocity = 1; 

	//!<Keeps track of the time passed... 
	private int timer; 

	bool dropTimerStarted; 

	Vector3 resetPosition; 

	Rigidbody2D body; 

	// Use this for initialization
	void Start () {
		//Establish the position the platform should be reset to after it has droped 
		this.resetPosition = this.gameObject.transform.position; 

		//!< Get the rigidbody attached to this obj 
		body = this.GetComponentInChildren<Rigidbody2D> (); 

	}
	
	// Update is called once per frame
	void Update () {

		if (dropTimerStarted) {
			timer += (int)(Time.deltaTime * 1000);

			if (timer > dropDelayMS){

				//!< Then apply downwards velocity... 
				this.body.velocity = new Vector2(this.body.velocity.x, this.dropVelocity); 

				//!< Reset platform after given time 
				if ((timer-dropDelayMS) > this.resetTimeMS){
					//!< set the velocity to zero 
					this.body.velocity = Vector2.zero; 
					this.gameObject.transform.position = this.resetPosition; 
					dropTimerStarted = false; 
					timer = 0; 
				}

			}
		}
	}

	//!< If the player collides with the platform we will start the falling timer etc..
	void OnCollisionEnter2D(Collision2D obj) {
		if (obj.gameObject.tag == "Player") {
			this.dropTimerStarted = true; 
		}
	}

}
