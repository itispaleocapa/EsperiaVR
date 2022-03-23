using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour {

    public Vector3 position;
    public Vector3 rotation;

    private Transform vrCam;
    private Transform hand;


	// Use this for initialization
	void Start () {
        vrCam = Camera.main.transform;
        hand = vrCam.Find("Hand");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pickup()
    {
        transform.parent = hand;
        /*transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;*/
        transform.localPosition = position;
        transform.localEulerAngles = rotation;
    }
}
