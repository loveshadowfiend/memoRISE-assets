using UnityEngine;

public class FlashlightObj : MonoBehaviour, IInteractable {
    private AudioSource audioSource;
    
    private void Start() {
        audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
        audioSource.Pause();
        
        if (PlayerScript.instance.hasFlashlight) {
            Destroy(gameObject);
        }
    }

    public void Interact() {
        PlayerScript.instance.hasFlashlight = true;
        audioSource.Play();
        Destroy(gameObject);
    }
}