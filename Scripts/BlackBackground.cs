using UnityEngine;

public class BlackBackground : MonoBehaviour {
    public float transparency = 0.5f;
    
    private void OnGUI() {
        // Set the background color with transparency
        Color backgroundColor = new Color(0f, 0f, 0f, transparency);
        GUI.color = backgroundColor;

        // Draw a fullscreen rectangle as the black background
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture, ScaleMode.StretchToFill);
    }
}