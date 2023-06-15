using UnityEngine;

public class PianoGuide : MonoBehaviour, IInteractable {
    private AudioSource audioSource;
    private void Start() {
        audioSource = GameObject.Find("Paper").GetComponent<AudioSource>();
        audioSource.Pause();

        if (PlayerScript.instance.hasPianoGuide) {
            Destroy(gameObject);
        }
    }

    public void Interact() {
        PlayerScript.instance.hasPianoGuide = true;
        audioSource.Play();
        PlayerScript.instance.ShowSubtitles("Какие-то ноты. Давно мечтал начать играть на пианино.", 3);
        
        Destroy(gameObject);
    }
}
