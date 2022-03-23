using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public Transform vrCamera;
    public float speed = 3.0f;
    public float angoloMin = 30.0f;
    public float angoloMax = 60.0f;
    private CharacterController cc;
    private bool moveForward;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {

        // Rampo 2021-12-22 - rotazioni da tastiera
        float delta = Mathf.PI / 16;
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //sinistra
            cc.transform.Rotate(new Vector3(0, -delta, 0), Space.World);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            //destra
            cc.transform.Rotate(new Vector3(0, delta, 0), Space.World);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            //alto
            cc.transform.Rotate(new Vector3(delta, 0, 0), Space.Self);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            //basso
            cc.transform.Rotate(new Vector3(-delta, 0, 0), Space.Self);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            //basso
            cc.transform.Rotate(new Vector3(0, 0, 0));
        }

        // Crotti 2021-12-22 - rotazioni con mouse
        float mouseX = Input.GetAxis("Mouse X") * speed / 2;
        float mouseY = Input.GetAxis("Mouse Y") * speed / 2;

        if (mouseX != 0 || mouseY != 0)     //se c'è movimento mouse
        {
            //si tiene conto solo del movimento prevalente: se maggiore orizzontale rotazione sx-dx se maggiore verticale rotazione alto-basso
            if (Mathf.Abs(mouseX)> Mathf.Abs(mouseY))
                cc.transform.Rotate(0, mouseX, 0, Space.World);
            else
                if ((vrCamera.eulerAngles.x - mouseY >= 360 - angoloMax || vrCamera.eulerAngles.x - mouseY <= angoloMax) && (vrCamera.eulerAngles.x - mouseY <= 360 - angoloMax || vrCamera.eulerAngles.x - mouseY >= angoloMax))
                    cc.transform.Rotate(-mouseY, 0, 0, Space.Self);
        }


        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (v != 0 || h != 0)
            cc.SimpleMove(((vrCamera.forward * v) + (vrCamera.right * h)) * speed);
        else {
            if (vrCamera.eulerAngles.x >= angoloMin && vrCamera.eulerAngles.x < angoloMax)
                moveForward = true;
            else
                moveForward = false;

            if (moveForward)
                cc.SimpleMove(vrCamera.forward * speed);
        }

        
        if (Input.GetKey(KeyCode.Escape)){
            //rampo 2022-01-18
            //if(UnityEditor.EditorUtility.DisplayDialog("Terminazione","Vuoi terminare?", "Sì", "No"))
            Application.Quit(); 
        }

    }
}
