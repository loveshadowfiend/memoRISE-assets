using UnityEngine;

interface IInteractable {
    public void Interact();
}
public class Interactor : MonoBehaviour {
    public GameObject interactText;
    public Transform cam;
    public float interactRange = 1f;

    private void Start() {
        interactText = GameObject.Find("InteractText");
    }
    private void Update() {
        // if raycast hits an object with desired range
        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hit, interactRange)) {
            // if E is pressed object is interactable
            if (hit.transform.gameObject.TryGetComponent(out IInteractable interactObj)) {
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    interactObj.Interact();
                }
            }
            else {
                interactText.gameObject.SetActive(false);
            }
        }
        else {
            interactText.gameObject.SetActive(false);
        }
    }
}