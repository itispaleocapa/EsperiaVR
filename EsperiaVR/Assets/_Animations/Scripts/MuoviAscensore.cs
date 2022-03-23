using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuoviAscensore : MonoBehaviour {

    public int floor;

    private Animator animAscensore;    

    // Use this for initialization
    void Start()
    {
        /*MuroAscensore = GameObject.Find("MuroAscensore" + floor).transform;
        animPorta = MuroAscensore.Find("PortaAscensore").GetComponent<Animator>();*/
        animAscensore = GameObject.Find("Ascensore").transform.GetComponent<Animator>();
    }

    public void chiamaAscensore()
    {
        animAscensore.SetInteger("floor", floor);
    }
}
