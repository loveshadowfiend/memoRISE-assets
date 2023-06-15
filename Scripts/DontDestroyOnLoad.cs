using System;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
    private void Start() {
        if (PlayerScript.instance.hasBedroomKey) {
            Destroy(this);
            return;
        }
        
        DontDestroyOnLoad(this);
    }
}