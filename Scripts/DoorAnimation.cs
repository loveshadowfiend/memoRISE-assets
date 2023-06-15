using System;
using UnityEngine;

public class DoorAnimation : MonoBehaviour, IInteractable {
    private bool isOpened;
    private Animator objectAnimator;
    private AudioSource[] audioSources;

    bool AnimatorIsPlaying(){
        return objectAnimator.GetCurrentAnimatorStateInfo(0).length >
               objectAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    
    private void Start() {
        objectAnimator = transform.GetComponent<Animator>();

        audioSources = transform.parent.gameObject.GetComponents<AudioSource>();
    }

    public void Interact() {
        if (AnimatorIsPlaying()) return;
        
        if (!isOpened) {
            objectAnimator.Play("Open", 0, 0.0f);
            audioSources[0].Play();
        }
        else {
            objectAnimator.Play("Close", 0, 0.0f);
            audioSources[1].Play();
        }
        isOpened = !isOpened;
    }
}
