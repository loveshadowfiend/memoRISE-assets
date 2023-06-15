using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class IntroCutscene : MonoBehaviour {
    private PlayableDirector playableDirector;

    void Start() {
        playableDirector = GetComponent<PlayableDirector>();
    }

    void Update() {
        if (playableDirector.state != PlayState.Playing) {
            SceneManager.LoadScene("Bedroom");
        }
    }
}