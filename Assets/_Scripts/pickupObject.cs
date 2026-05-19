using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickupObject : MonoBehaviour {

    private Transform vrCam;
    private Transform hand;


	// Use this for initialization
	void Start () {
        vrCam = SceneManager.GetSceneByName("VRMain").GetRootGameObjects()[0].transform;
        hand = vrCam.Find("Main Camera").Find("Hand");
        Debug.Log("Hand found: " + hand.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pickup()
    {
        transform.parent = hand;
        /*transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;*/
        transform.localPosition = new Vector3(-0.113f, 0.047f, -0.447f);
        transform.localEulerAngles = new Vector3(-140.6f, -16.96f, 0);
    }
}
