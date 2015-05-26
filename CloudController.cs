using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CloudController : MonoBehaviour {


    //!< Quite far back 
    public int sortingOrder = -100;

	// Use this for initialization
	void Start () {
	    //!< Set the sorting layer of the clouds 
        Renderer renderer = this.GetComponent<Renderer>();
        renderer.sortingOrder = this.sortingOrder;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
