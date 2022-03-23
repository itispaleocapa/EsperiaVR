using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccendiSpegni : MonoBehaviour
{
    public Transform oggetto;
    public Material matAcceso;
    public Material matSpento;
    public Transform oggettoRichiesto;

    private MeshRenderer myRenderer;    
    private bool acceso;
    private Transform hand;

    // Use this for initialization
    void Start()
    {
        myRenderer = oggetto.GetComponent<MeshRenderer>();
        hand = Camera.main.transform.Find("Hand");
    }

    public void ToggleStatus()
    {
        if (oggettoRichiesto == null || (hand.childCount>1 && oggettoRichiesto.name == hand.GetChild(1).name))
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
