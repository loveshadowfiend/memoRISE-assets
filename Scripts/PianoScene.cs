using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PianoScene : MonoBehaviour {
    public GameObject[] keys;
    public AudioSource[] keyAudio;
    private int currentKeyIndex = 23;
    private int sequenceIndex = 0;
    private AudioSource ClaireDeLune;

    // TODO: add delay to A and D key
    private bool canCheckKey = true;
    private float timer = 0f;
    private float delay = 1f;

    private List<int> keySequence = new List<int>() {
        30, 32, 31, 30, 33, 37, 33, 35, 22, 25, 27, 37, 35, 33, 32, 30
    };

    private void ActivateKey(int index) {
        if (index >= 0 && index < keys.Length) {
            Renderer keyRenderer = keys[index].GetComponent<Renderer>();
            keyRenderer.material.color = Color.grey;
        }
    }

    private void DeactivateKey(int index) {
        if (index >= 0 && index < keys.Length) {
            Renderer keyRenderer = keys[index].GetComponent<Renderer>();
            keyRenderer.material.color = Color.white;
        }
    }

    private void HighlightSequence() {
        if (currentKeyIndex == keySequence[sequenceIndex]) return;
        Renderer keyRenderer = keys[keySequence[sequenceIndex]].GetComponent<Renderer>();
        keyRenderer.material.color = Color.yellow;
    }

    IEnumerator SceneExit() {
        yield return new WaitForSeconds(1);
        
        GetComponent<ScreenFade>().StartFade();
    }

    private void Start() {
        ActivateKey(currentKeyIndex);

        ClaireDeLune = GameObject.Find("Music").GetComponent<AudioSource>();
        ClaireDeLune.Pause();
    }

    private void Update() {
        if (sequenceIndex >= keySequence.Count) {
            StartCoroutine(SceneExit());
            return;
        }
        
        if (PlayerScript.instance.hasPianoGuide) {
            HighlightSequence();
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            DeactivateKey(currentKeyIndex);
            currentKeyIndex++;
        
            if (currentKeyIndex >= keys.Length) {
                currentKeyIndex = 0;
            }
        
            ActivateKey(currentKeyIndex);
        }
        
        if (Input.GetKeyDown(KeyCode.A)) {
            DeactivateKey(currentKeyIndex);
            currentKeyIndex--;
        
            if (currentKeyIndex < 0) {
                currentKeyIndex = keys.Length - 1;
            }
        
            ActivateKey(currentKeyIndex);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (currentKeyIndex >= 0 && currentKeyIndex < keyAudio.Length) {
                keyAudio[currentKeyIndex].Play();
                if (PlayerScript.instance.hasPianoGuide && currentKeyIndex == keySequence[sequenceIndex]) {
                    sequenceIndex++;
                }
            }
        }

        // handle scene exit
        if (Input.GetKeyDown(KeyCode.E)) {
            PlayerScript.instance.Enable();
            SceneManager.LoadScene("Hall");
            SaveUIState.instance.Enable();
            
            ClaireDeLune.Play();
        }
    }
}