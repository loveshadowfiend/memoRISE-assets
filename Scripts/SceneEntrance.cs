using UnityEngine;

public class SceneEntrance : MonoBehaviour {
    public string lastExitName;

    void Start() {
        if (PlayerPrefs.GetString("LastExitName") == lastExitName) {
            PlayerScript.instance.transform.position = transform.position;
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
            // GameObject.Find("Music").GetComponent<AudioSource>().Play();
        }
    }
}