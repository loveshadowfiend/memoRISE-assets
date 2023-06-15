using UnityEngine;

public class InteractSound : MonoBehaviour, IInteractable {
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.Pause();
    }

    public void Interact() {
        audioSource.Play();
    }
}