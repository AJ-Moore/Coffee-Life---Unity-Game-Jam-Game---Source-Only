using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//!< The maximun distance before the camera will move to the player 
	public float camMaxDist = 0;
	public float cameraSpeedMultiplier = 1;
    public float cameraSize = 5;
    public float zoomFactor = 1; 

	//!< Whether the camera is moving 
	protected bool camMoving = false;

    float cameraDefault = 5; 

	PlayerController player; 

	//!< Time Keeping 
	private float startTime;
	private float journeyLength;

    Camera camera; 

	// Use this for initialization
	void Start () {
		//!< Get the player controller 
		player = GameObject.FindObjectOfType<PlayerController> ();
        camera = GameObject.FindObjectOfType<Camera>();

		//!< Start at the players position 
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        this.cameraDefault = this.cameraSize;

	}
	
	// Update is called once per frame
	void Update () {
	//void FixedUpdate() {

        this.CheckControls();
			
		//!< If the cameras not already moving 
		if (!this.camMoving) {
			//!< If distance if greater than a given value
			if (Vector2.Distance (this.transform.position, this.player.transform.position) > this.camMaxDist) {
				//!< move to players position 
				this.camMoving = true; 
				journeyLength = Vector2.Distance (this.transform.position, this.player.transform.position);
				//!< set the start time of the translation 
				this.startTime = Time.time; 
			}
		
		} else {
			this.UpdateCameraMovement(); 
		}

	}

    void CheckControls(){

        float zoomVal = Input.GetAxis("Zoom");

        //Debug.Log("CHECKCONTROLS");
        if (zoomVal != 0){
            //Debug.Log("Input Detected");
             camera.orthographicSize += - ((zoomVal * zoomFactor) * Time.deltaTime);
        }

        if (Input.GetAxis("ResetCamera") > 0){
            camera.orthographicSize = this.cameraDefault;
        }
        
    }



	void UpdateCameraMovement(){
		float distRemaining = Vector2.Distance (this.transform.position, this.player.transform.position);
		float distTraveled = (Time.time - startTime) * (this.cameraSpeedMultiplier*(distRemaining));
		float fracJourney = distTraveled / journeyLength;
		Vector3 position = Vector3.Lerp(this.transform.position, this.player.transform.position, fracJourney);
        position.z = -10; 
		//float roundedx = Mathf.Round(position.x * 1000.0f) / 1000.0f;//to4ddp
		//float roundedy = Mathf.Round(position.y * 1000.0f) / 1000.0f;
		this.transform.position = position;

		if ((this.transform.position.x == this.player.transform.position.x ) &&
		    (this.transform.position.y == this.player.transform.position.y )){
				this.camMoving = false;
		}
	}

}
