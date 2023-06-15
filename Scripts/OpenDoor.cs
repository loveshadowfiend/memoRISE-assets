using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour {
    public string sceneToLoad;

    void Start() {
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.E)) {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
