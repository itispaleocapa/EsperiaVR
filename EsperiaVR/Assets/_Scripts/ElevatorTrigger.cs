using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour {

    private Transform oldParent;
    private Transform newParent;

    void Start()
    {
        oldParent = gameObject.transform.parent;
        newParent = gameObject.transform;
    }

    void OnTriggerEnter(Collider collider)
    {
        Camera.main.transform.SetParent(newParent);
    }

    void OnTriggerExit(Collider collider)
    {
        Camera.main.transform.SetParent(oldParent);
    }
}
