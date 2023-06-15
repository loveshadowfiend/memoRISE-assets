using UnityEngine;

public class PaintingScript : MonoBehaviour, IInteractable {
    [SerializeField] private GameObject key;
    private Animator objectAnimator;
    private bool isDropped;
    private AudioSource audioSource;

    void Start() {
        objectAnimator = transform.GetComponent<Animator>();
        key.gameObject.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Pause();
    }

    public void Interact() {
        if (isDropped) return;

        objectAnimator.Play("Drop", 0, 0.0f);
        audioSource.Play();
        if (!PlayerScript.instance.hasBedroomKey) key.gameObject.SetActive(true);
        isDropped = true;
        
    }
}