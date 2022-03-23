using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerScene : MonoBehaviour {

    public bool Enabled = true;
    public string[] sceneToLoad;
    //public string[] sceneActive;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (Enabled)
            {
                Debug.Log("Trigger enter");
                foreach (string scena in sceneToLoad)
                {
                    //Debug.Log(scena.name + SceneManager.GetSceneByName(scena.name).isLoaded);
                    if (!SceneManager.GetSceneByName(scena).isLoaded)
                        SceneManager.LoadSceneAsync(scena, LoadSceneMode.Additive);
                }
                for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    Scene scena = SceneManager.GetSceneAt(i);
                    Debug.Log(i + scena.name);
                    bool trovato = false;
                    if (scena.name == "Skydome" || scena.name == "VRMain" || scena.name == "Atrio1" || scena.name == "Atrio2" || scena.name == "Atrio3" || scena.name == "Elevator") trovato = true;
                    for (int j = 0; j < sceneToLoad.Length; j++)
                    {
                        Debug.Log("NomeScena: " + scena.name + " ScenaAttiva: " + sceneToLoad[j]);
                        if (scena.name == sceneToLoad[j]) trovato = true;
                    }
                    if (!trovato) SceneManager.UnloadSceneAsync(scena.name);
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {            
            if (Enabled)
            {
                Debug.Log("Trigger exit");
               /* for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    Scene scena = SceneManager.GetSceneAt(i);
                    Debug.Log(i + scena.name);
                    bool trovato = false;
                    if (scena.name == "Skydome" || scena.name == "VRMain" || scena.name == "Atrio1" || scena.name == "Atrio2" || scena.name == "Atrio3") trovato = true;
                    for (int j = 0; j < sceneToLoad.Length; j++)
                    {
                        Debug.Log("NomeScena: " + scena.name + " ScenaAttiva: " + sceneToLoad[j]);
                        if (scena.name == sceneToLoad[j]) trovato = true;
                    }
                    if (!trovato) SceneManager.UnloadSceneAsync(scena.name);
                }*/
            }
        }
    }
}
