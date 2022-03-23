using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApriChiudi : MonoBehaviour {

    private Animator myAnim;
    private bool isopen;

    // Use this for initialization
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    public void toggleStatus()
    {
        if (isopen) close();
        else open();
    }

    void open()
    {
        //Debug.Log("apri");
        isopen = true;
        myAnim.SetBool("open", isopen);
    }

    void close()
    {
        //Debug.Log("chiudi");
        isopen = false;
        myAnim.SetBool("open", isopen);
    }
}
