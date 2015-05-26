using UnityEngine;
using System.Collections;

//Automatically adds a type of audio source to the object.
[RequireComponent(typeof(AudioSource))]
public class Bounce : MonoBehaviour {

	public float bounceForce = 1; 

	public AudioClip bounceSound; 
	private AudioSource audio;

	protected PlayerController player; 
	

	// Use this for initialization
	void Start () {
	
		//retain player for reference 
		player = GameObject.FindObjectOfType<PlayerController> ();
		this.audio = this.GetComponentInChildren<AudioSource> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D obj) {

		Rigidbody2D body = obj.gameObject.GetComponent<Rigidbody2D> ();
		if (body == null)
			return; 

		//else
		//body.AddForce(new Vector2 (0, bounceForce));
		body.velocity = new Vector2(body.velocity.x, bounceForce);
		this.audio.PlayOneShot (this.bounceSound); 

		//Important to set the player as airborne to prevent them from jumping// Hard coded in player
		/*if (obj.gameObject.tag == "Player") {
			player.setAirborne(true);  
		}
		*/
	}
}
