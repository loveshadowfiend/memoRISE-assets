using System;
using UnityEngine;
using UnityEngine.Playables;

public class Ending : MonoBehaviour {
    private PlayableDirector director;

    private void Start() {
        director = GameObject.Find("Camera").GetComponent<PlayableDirector>();
    }

    private void Update() {
        if (director.state == PlayState.Paused) {
            Application.Quit();
        }
    }
}