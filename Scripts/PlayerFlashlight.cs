using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour {
    private bool isFlashlightActive = false;

    [SerializeField] private GameObject flashlightLight;

    void Start() {
        flashlightLight.gameObject.SetActive(false);
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && PlayerScript.instance.hasFlashlight) {
            isFlashlightActive = !isFlashlightActive;
            flashlightLight.gameObject.SetActive(isFlashlightActive);
        }
    }
}