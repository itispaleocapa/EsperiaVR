using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AccendiSpegni : MonoBehaviour
{
    public Transform oggetto;
    public Material matAcceso;
    public Material matSpento;
    public Transform oggettoRichiesto;

    private MeshRenderer myRenderer;    
    private bool acceso;
    private Transform vrCam;
    private Transform hand;

    // Use this for initialization
    void Start()
    {
        myRenderer = oggetto.GetComponent<MeshRenderer>();
        vrCam = SceneManager.GetSceneByName("VRMain").GetRootGameObjects()[0].transform;
        hand = vrCam.Find("Main Camera").Find("Hand");
    }

    public void ToggleStatus()
    {
        if (oggettoRichiesto == null || (hand.childCount>=1 && oggettoRichiesto.name == hand.GetChild(0).name))
        {
            if (acceso)
            {
                acceso = false;
                myRenderer.material = matSpento;
            }
            else
            {
                acceso = true;
                myRenderer.material = matAcceso;
            }
        }       

    }
}
