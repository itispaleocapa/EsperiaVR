using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public bool Enabled = true;
    public string[] sceneStart;

	// Use this for initialization
	void Start () {

        if (Enabled)
        {
           foreach (string scena in sceneStart)
           {
                //Debug.Log(scena.name + SceneManager.GetSceneByName(scena.name).isLoaded);
                if (!SceneManager.GetSceneByName(scena).isLoaded)
                    SceneManager.LoadScene(scena, LoadSceneMode.Additive);
           }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
