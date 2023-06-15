using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LookTrigger : MonoBehaviour {
    [SerializeField] private GameObject angel, angelCam;
    private GameObject player;
    private bool isUsed;

    private void Start() {
        if (PlayerScript.instance.isScreamerUsed) Destroy(this);
        player = GameObject.Find("Player");
    }

    IEnumerator screamer() {
        PlayerScript.instance.ShowSubtitles("", 1);
        player.SetActive(false);
        angelCam.SetActive(true);

        yield return new WaitForSeconds(1f);
        
        player.SetActive(true);
        angelCam.SetActive(false);
        Destroy(this);
    }

    private void OnTriggerExit(Collider other) {
        if (PlayerScript.instance.hasPianoGuide) {
            angel.GetComponent<Angel>().lookAt(transform);

            if (!PlayerScript.instance.isScreamerUsed) {
                StartCoroutine(screamer());
                PlayerScript.instance.isScreamerUsed = true;
            }
        }
    }
}