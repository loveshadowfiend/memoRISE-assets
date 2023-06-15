using UnityEngine;
using UnityEngine.UI;

public class BlackOutScreen : MonoBehaviour {
    public float transparency = 1f;
    private Image image;

    private void Start() {
        // Set the background color with transparency
        Color backgroundColor = new Color(0f, 0f, 0f, 1f - transparency);
        image = GetComponent<Image>();
        image.color = backgroundColor;
    }

    private void Update() {
        if (PlayerScript.instance.isInteracted) {
            transparency = 0.25f;
            Color backgroundColor = new Color(0f, 0f, 0f, 1f - transparency);
            image.color = backgroundColor;
        }
        else {
            transparency = 1f;
            Color backgroundColor = new Color(0f, 0f, 0f, 1f - transparency);
            image.color = backgroundColor;
        }
    }
}