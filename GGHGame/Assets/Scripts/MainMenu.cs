using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void LoadLevel (string levelName) {
        // This will load another scene and takes parameter index of scene or string name
        SceneManager.LoadScene(levelName);
    }
    public void QuitGame() {
        Application.Quit ();
    }
}