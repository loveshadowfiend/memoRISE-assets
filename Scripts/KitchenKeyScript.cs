using UnityEngine;

public class KitchenKeyScript : MonoBehaviour, IInteractable {
    private AudioSource audioSource;
    void Start() {
        audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
        audioSource.Pause();
        
        if (PlayerScript.instance.hasLibraryKey) {
            Destroy(gameObject);
        }
    }

    public void Interact() {
        PlayerScript.instance.hasLibraryKey = true;
        audioSource.Play();
        Destroy(gameObject);
    }
}