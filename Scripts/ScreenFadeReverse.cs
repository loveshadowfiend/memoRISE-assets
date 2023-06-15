using UnityEngine;

public class ScreenFadeReverse : MonoBehaviour {
    private float alpha = 1f;
    private float fadeSpeed = 0.1f;
    private bool isFading = true;

    private void OnGUI() {
        if (isFading) {
            alpha -= fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(1f, 1f, 1f, alpha);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);

            if (alpha <= 0f) {
                isFading = false;
            }
        }
    }
}