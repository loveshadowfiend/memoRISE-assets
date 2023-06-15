using UnityEngine;

public class Angel : MonoBehaviour {
    private Renderer objectRenderer;
    private Transform parent;
    private Transform target;

    private void Start() {
        objectRenderer = GetComponent<Renderer>();
        target = GameObject.Find("Player").transform;
        parent = transform.parent.transform;
    }

    private void Update() {
        if (!objectRenderer.isVisible) {
            lookAt(target);
        }
    }

    public void lookAt(Transform target) {
        Vector3 targetPosition =
            new Vector3(target.transform.position.x, parent.position.y, target.transform.position.z);
            
        parent.LookAt(targetPosition);
    }
}