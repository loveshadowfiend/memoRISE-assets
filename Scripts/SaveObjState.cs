using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveObjState : MonoBehaviour {
    private GameObject childObj;
    private string initScene;
    private void Start() {
        if (GameObject.Find(gameObject.name).scene.name == "DontDestroyOnLoad") {
            Destroy(gameObject);
        }
        
        initScene = gameObject.scene.name;
        childObj = transform.GetChild(0).gameObject;
        
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (childObj.name == "Music") return;
        
        if (SceneManager.GetActiveScene().name == initScene) {
            childObj.SetActive(true);
        }
        else {
            childObj.SetActive(false);
        }
    }
}