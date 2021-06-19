// Various examples of scene management
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagementExamples : MonoBehaviour {

    // Name of new scene. Should be add the scene in build settings.
    public string scene;

    // Load the new scene
    public void LoadScene(string newScene) {
        SceneManager.LoadScene(newScene);
    }

    // Reload the current scene
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}