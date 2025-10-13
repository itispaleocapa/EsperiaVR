using System;
using UnityEngine;

public class ApriChiudiAscensore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator myAnim;
    private bool isopen;
    private MeshCollider myCollider;
    // Use this for initialization
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<MeshCollider>();
    }

    public void toggleStatus()
    {
        if (isopen == true)
            close();
        else
            open();
    }

    void open()
    {
        Debug.Log("apri");
        isopen = true;
        myAnim.SetBool("open", isopen);
    }

    void close()
    {
        Debug.Log("chiudi");
        isopen = false;
        myAnim.SetBool("open", isopen);
    }
    void Update()
    {
        if (myAnim.GetBool("open") == false)
        {
            myCollider.convex = true;
        }
        else
        {
            myCollider.convex = false;
        }
    }
}
