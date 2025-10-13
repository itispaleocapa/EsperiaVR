using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorTrigger : MonoBehaviour {

    private Transform oldParent;
    private Transform newParent;

    void Start()
    {
        newParent = gameObject.transform.parent;
        oldParent = Camera.main.transform.parent;
    }

    void OnTriggerEnter(Collider collider)
    {
        Camera.main.transform.SetParent(newParent);
        Camera.main.transform.localScale = Vector3.one * 0.2f;
    }

    void OnTriggerExit(Collider collider)
    {
        Camera.main.transform.SetParent(oldParent);
        Camera.main.transform.localScale = Vector3.one;
    }
}
