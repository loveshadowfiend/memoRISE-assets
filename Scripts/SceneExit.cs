using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour, IInteractable {
    [SerializeField] private GameObject player;
    public string sceneToLoad, exitName;
    private AudioSource[] audioSources;

    private void Start() {
        audioSources = gameObject.GetComponents<AudioSource>();
    }

    public void Interact() {
        if (sceneToLoad == "Hall" && !PlayerScript.instance.hasBedroomKey) {
            PlayerScript.instance.ShowSubtitles("Дверь не поддается... Кажется, нужно найти ключ", 3);
            audioSources[0].Play();
            return;
        }

        if (sceneToLoad == "Library" && !PlayerScript.instance.hasLibraryKey) {
            PlayerScript.instance.ShowSubtitles("Дверь не поддается... Кажется, нужно найти ключ", 3);
            audioSources[0].Play();
            return;
        }

        if (sceneToLoad == "Ending") {
            PlayerScript.instance.ShowSubtitles("Похоже, это дверь наружу, но, кажется, \n что даже ключ не поможет ее открыть.", 3);
            audioSources[0].Play();
            return; 
        }

        if (sceneToLoad == "Piano") PlayerScript.instance.Disable();

        PlayerPrefs.SetString("LastExitName", exitName);
        // GameObject.Find("Music").GetComponent<AudioSource>().Pause();
        // audioSources[1].Play();
        PlayerScript.instance.ShowSubtitles("", 1);
        SceneManager.LoadScene(sceneToLoad);
    }
}