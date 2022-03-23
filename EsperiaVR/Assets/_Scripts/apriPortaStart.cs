using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apriPortaStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Animator>().SetBool("open", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
