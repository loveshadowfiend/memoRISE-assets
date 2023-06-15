using UnityEngine;

public class SaveUIState : MonoBehaviour {
    public static SaveUIState instance;

    public void Enable() {
        gameObject.SetActive(true);
    }

    public void Disable() {
        gameObject.SetActive(false);
    }
    private void Start() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}