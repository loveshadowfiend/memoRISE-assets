using UnityEngine;
using UnityEngine.UI;

public class FlashlightHint : MonoBehaviour {
    private Text text;
    [SerializeField] private GameObject flashlight;

    private void Start() {
        text = gameObject.GetComponent<Text>();
        text.text = "";
        
        if (PlayerScript.instance.hasFlashlight) {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F) && PlayerScript.instance.hasFlashlight) {
            flashlight.SetActive(true);
            Destroy(gameObject);
        }
        
        if (PlayerScript.instance.hasFlashlight) {
            text.text = "[F] включить фонарик";
        }
    }
}