using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class ScreenFade : MonoBehaviour {
    private float alpha = 0f;
    private float fadeSpeed = 0.05f;
    private bool isFading;

    [SerializeField] private GameObject heartbeat;

    IEnumerator SceneChangeToEnding() {
        heartbeat.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        heartbeat.gameObject.SetActive(false);
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Ending");
    }

    private void Start() {
        heartbeat.SetActive(false);
    }

    private void OnGUI() {
        if (isFading) {
            alpha += fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(1f, 1f, 1f, alpha);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);

            if (alpha >= 1f) {
                StartCoroutine(SceneChangeToEnding());
            }
        }
    }

    public void StartFade() {
        isFading = true;
    }
}