using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Transform visuale;
    public float speed = 3.0f;
    public float angoloMin = 45.0f;
    public float angoloMax = 60.0f;
    private CharacterController cc;
    private float v ;
    private float h ;
    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //impedisce allo schermo di spegnersi
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (v != 0 || h != 0)
            cc.SimpleMove(((visuale.forward * v) + (visuale.right * h)) * speed);
        else if (visuale.eulerAngles.x >= angoloMin && visuale.eulerAngles.x <= angoloMax)
        {
            cc.SimpleMove(visuale.forward * speed);
        }   
    }
    //movimento tramite nuovo sistema input
    void OnMove(InputValue movementvalue)
    {
        Vector2 movementVector = movementvalue.Get<Vector2>();
        v = movementVector.y;
        h = movementVector.x;
    }
    //rotazione tramite nuovo sistema input
    void OnLook(InputValue lookvalue)
    {
        Vector2 lookVector = lookvalue.Get<Vector2>();
        float mouseX = lookVector.x/2;
        float mouseY = lookVector.y/2;

        if (mouseX != 0 || mouseY != 0)     //se c'è movimento mouse
        {
            //si tiene conto solo del movimento prevalente: se maggiore orizzontale rotazione sx-dx se maggiore verticale rotazione alto-basso
            if (Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
                cc.transform.Rotate(0, mouseX, 0, Space.World);
            else if((visuale.eulerAngles.x - mouseY >= 360 - angoloMax || visuale.eulerAngles.x - mouseY <= angoloMax) && (visuale.eulerAngles.x - mouseY <= 360 - angoloMax || visuale.eulerAngles.x - mouseY >= angoloMax))
                cc.transform.Rotate(-mouseY, 0, 0, Space.Self);
        }
    }
}
