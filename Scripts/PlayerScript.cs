using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    public static PlayerScript instance;
    public bool hasFlashlight, hasBedroomKey, hasLibraryKey, hasPianoGuide, isInteracted, isScreamerUsed;
    public FirstPersonController fpc;

    public void DisableControls() {
        Time.timeScale = 0f;
        fpc.enabled = false;
    }

    public void EnableControls() {
        Time.timeScale = 1f;
        fpc.enabled = true;
    }

    public void Disable() {
        gameObject.SetActive(false);
    }

    public void Enable() {
        gameObject.SetActive(true);
    }

    private IEnumerator SubtitlesCoroutine(string txt, int seconds) {
        GameObject subtitlesGameObject = GameObject.Find("Subtitles");
        Text subtitles = subtitlesGameObject.GetComponent<Text>();

        subtitles.text = txt;
        yield return new WaitForSeconds(seconds);
        subtitles.text = "";
    }

    public void ShowSubtitles(string txt, int seconds) {
        StartCoroutine(SubtitlesCoroutine(txt, seconds));
    }
    
    public void Start() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            PlayerPrefs.DeleteAll();
            fpc = GetComponent<FirstPersonController>();
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}