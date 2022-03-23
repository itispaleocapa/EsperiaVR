using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    private Animator myAnim;
    private bool isFlying;

	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
	}
	
    public void startFlying()
    {
        isFlying = true;
        myAnim.SetBool("IsFlying", isFlying);
    }

    public void stopFlying()
    {
        isFlying = false;
        myAnim.SetBool("IsFlying", isFlying);
    }
}
