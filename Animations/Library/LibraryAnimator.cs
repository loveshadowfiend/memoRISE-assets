using System.Collections;
using UnityEngine;

public class LibraryAnimator : MonoBehaviour, IInteractable {
    public AudioSource[] audioSource;
    [SerializeField] private GameObject obj;
    private Animator objectAnimator;
    private bool isOpened;

    private IEnumerator Open() {
        if (!isOpened) {
            isOpened = true;
            objectAnimator.Play("Open", 0, 0.0f);
            // audioSource[0].Play();
        }

        yield return new WaitForSeconds(0);
    }

    private void Start() {
        objectAnimator = obj.GetComponent<Animator>();
    }

    public void Interact() {
        GetComponent<NoteScript>().Interact();
        StartCoroutine(Open());
    }
}