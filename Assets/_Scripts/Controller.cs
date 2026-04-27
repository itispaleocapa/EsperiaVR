using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Transform visuale;
    public float speed = 3.0f;
    private CharacterController cc;
    private float time;
    private static WaitForSeconds _wait = new WaitForSeconds(1.5f);
    float x, y;
    float angoloMax = 60f;
    float angoloMin = 45f;
    float mouseX, mouseY;
    public VrModeController vrModeController;
    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //impedisce allo schermo di spegnersi
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
        vrModeController = GetComponent<VrModeController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(visuale.position.x, transform.position.y, 0);
        if (visuale.eulerAngles.x >= angoloMin && visuale.eulerAngles.x <= angoloMax)
            cc.SimpleMove(visuale.forward * speed);
        else
            cc.SimpleMove(visuale.forward * y * speed + visuale.right * x * speed);
        visuale.rotation = Quaternion.Euler(visuale.eulerAngles.x - mouseY, visuale.eulerAngles.y + mouseX, 0);
    }
    //movimento tramite nuovo sistema input
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();
        y = movementVector.y;
        x = movementVector.x;
    }
    //rotazione tramite nuovo sistema input
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookVector = context.ReadValue<Vector2>();
        mouseX = lookVector.x;
        mouseY = lookVector.y;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            vrModeController.ToggleVR();
        }
    }
}
