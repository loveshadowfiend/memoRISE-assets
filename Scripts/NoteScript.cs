using UnityEngine;

public class NoteScript : MonoBehaviour, IInteractable {
    [SerializeField] private GameObject note;
    private GameObject interactText;
    private AudioSource audioSource;

    private void OpenNote() {
        note.gameObject.SetActive(true);
        PlayerScript.instance.isInteracted = true;
        PlayerScript.instance.DisableControls();
    }

    private void CloseNote() {
        note.gameObject.SetActive(false);
        PlayerScript.instance.isInteracted = false;
        PlayerScript.instance.EnableControls();
    }

    public void Interact() {
        if (!PlayerScript.instance.isInteracted) {
            OpenNote();
            audioSource.Play();
        }
        else {
            CloseNote();
        }
    }
    
    private void Start() {
        interactText = GameObject.Find("InteractText");
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Pause();
    }

    private void Update() {
        if (PlayerScript.instance.isInteracted) {
            interactText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerScript.instance.isInteracted) {
            CloseNote();
        }
    }
}