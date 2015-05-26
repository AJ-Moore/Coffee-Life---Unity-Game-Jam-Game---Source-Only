using UnityEngine;
using System.Collections;

using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	//!< Movement Speed 
	public float moveSpeed = 1.0f; 
	public float jumpVelocity = 1.0f; 
	public int jumpDuractionMS = 1000; //max jump duration

	//!< How much time must pass before the player can jump again.
	public int jumpDelay = 100; 

	//!< Timers and other such things 
	public int jumpElapsedMS = 0; 
	protected int groundTimeMS = 0;

	//!< Players attached components
	protected Rigidbody2D body;  
	protected Collider2D collider; 

	//!< Respawn position 
	protected Vector2 respawnPos; 

	//!< The input recieved from the axis 
	protected float horizontalInput;

	//!< Set to true when the player is airborne
	protected bool airborne = false; 

	//!< If the player is currently jumping...
	protected bool isJumping;

	//!< Set to true when the jump button has been pressed 
	protected bool jumpPressed; 

	//!< Joystick used by player 
	protected Joystick JOY; 

	// Use this for initialization
	void Start () {

		//!< Retrieve the rigid body attached to this component
		this.body = this.GetComponent<Rigidbody2D> ();
		this.collider = this.GetComponent<Collider2D> (); 

		//!< Disable drag
		this.body.drag = 0.0f;

		//!< Set the respawn position. 
		this.respawnPos = this.transform.position; 

		this.JOY = GameObject.FindObjectOfType<Joystick> (); 
	
	}
	
	// Update is called once per frame
	void Update () {
		// Checks input events 
		//UpdateInput (); 
		UpdateMovement (); 
	}

	void FixedUpdate(){

		//!< Ensures accuracy by using fixed update 
		//this.CheckAirborne ();
		//UpdateInput (); 
	}
	void LateUpdate(){
		UpdateInput (); 
	}

	//!< On Collision callback 
	void OnCollisionEnter2D(Collision2D obj) {
		if (obj.gameObject.tag == "Bouncy") {
			this.airborne = true; 
		}
	}

	void UpdateInput(){

		//!< Get the horizontal motion i.e. 'a' + 'd' or left and right arrows 
		//this.horizontalInput = Input.GetAxis ("Horizontal"); 
	    
		this.horizontalInput = CrossPlatformInputManager.GetAxis ("Horizontal");

		//ifandroid 
		//this.horizontalInput = JOY.getX ();

		if (CrossPlatformInputManager.GetAxis ("Jump") > 0 || JOY.getJump()!= 0) {
			this.jumpPressed = true; 
		} else {
			this.jumpPressed = false; 
		}



	}
	

	//!< Called to updates the players movement.. apply forces etc... 
	void UpdateMovement(){

		//Set the velocity relational to input 
		this.body.velocity = new Vector2 (this.horizontalInput * this.moveSpeed,this.body.velocity.y);

		UpdateJump (); 
		//!< Checks to see if the player is airborne by casting a ray beneth the player 
		//CheckAirborne(); 

	}

	//!< The general idea behind jumping is the player will continue to rise 
	//!< within a given time so long as the jump button is still down 
	void UpdateJump(){

		this.jumpElapsedMS += (int)(Time.deltaTime * 1000);

		//!< Logic to check if player should be jumping go's here 
		if (!this.airborne) {
			//!< Jump button pressed 
			if (this.jumpPressed && this.groundTimeMS > this.jumpDelay){
				this.isJumping = true; 
			}
			this.jumpElapsedMS = 0; 
			this.groundTimeMS += (int)(Time.deltaTime * 1000);

		}



		//!< if already jumping check if key has been released 
		if (this.isJumping) {
			if (!this.jumpPressed){
				this.isJumping = false; 
				Debug.Log("JUMP RELEASED!!");
				//this.jumpElapsedMS = 0; 
			}
		}

		//While the player is jumping we set the velocity
		if (this.isJumping && this.jumpElapsedMS < this.jumpDuractionMS ) {
			this.groundTimeMS = 0;
			//this.body.velocity = new Vector2(this.body.velocity.x, this.body.velocity.y + this.jumpVelocity);
			this.body.velocity = new Vector2(this.body.velocity.x, this.jumpVelocity);
			Debug.Log("JUMPING");

		}

		//!< Done last in order to facilitate the effective overiding of airborne if necessary
		if (this.CheckAirborne ()) {
			this.airborne = true; 
		} else {
			if (this.airborne)
				this.groundTimeMS = 0; 
			this.airborne = false;
			//this.isJumping = false; 
		}

	}


	//!< Check if the player is airborne 
	bool CheckAirborne(){
		float dist = this.collider.bounds.extents.y;
		float distx = this.collider.bounds.extents.x;

		Vector2 position = new Vector2 (this.transform.position.x -distx, this.transform.position.y - dist - 0.1f);

		RaycastHit2D hit = Physics2D.Raycast (position, Vector2.right, dist*2);

		Debug.DrawRay (position, -Vector2.up);
		if (hit.collider != null){
			//Debug.Log("Grounded");
			if (hit.collider.gameObject.tag == "Bouncy" ||
			    hit.collider.gameObject.tag == "Pickup"){
				return true; 
			}
			return false; 
		}
		else{
			//Debug.Log("Airborne!"); 
			return true;
		}
	}


	//!< Respawns the player 
	public void respawn(){
		this.transform.position = this.respawnPos; 
	}


}
