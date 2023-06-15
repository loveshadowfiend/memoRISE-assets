using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    private GameObject pauseUI, interactText;
    private FirstPersonController fpc;
    private bool isPaused;
    
    private void Start() {
        pauseUI = gameObject.transform.GetChild(2).gameObject;
        pauseUI.SetActive(false);
        
        fpc = GameObject.Find("Player").GetComponent<FirstPersonController>();
        interactText = GameObject.Find("InteractText");
    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "Piano") {
            SaveUIState.instance.Disable();
        }

        if (PlayerScript.instance.isInteracted) return;
        
        if (isPaused) interactText.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) {
            isPaused = true;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pauseUI.gameObject.SetActive(true);
            PlayerScript.instance.DisableControls();
            GameObject.Find("Music").GetComponent<AudioSource>().Pause();
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = false;

            pauseUI.gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerScript.instance.EnableControls();
            GameObject.Find("Music").GetComponent<AudioSource>().Play();
        }
    }
}