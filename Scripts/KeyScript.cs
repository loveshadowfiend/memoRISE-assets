using UnityEngine;

public class KeyScript : MonoBehaviour, IInteractable {
    private AudioSource audioSource;
    
    public void Start() {
        audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
        audioSource.Pause();
        
        if (PlayerScript.instance.hasBedroomKey) {
            Destroy(gameObject);
        }   
    }
    public void Interact() {
        PlayerScript.instance.hasBedroomKey = true;
        audioSource.Play();
        Destroy(gameObject);
    }
}