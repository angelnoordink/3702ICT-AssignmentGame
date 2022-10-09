using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] public MiniGameCountSO miniGameCountSO;


    public void LoadLevel (string levelName ) {
        // This will load another scene and takes parameter index of scene or string name
        SceneManager.LoadScene(levelName);
        miniGameCountSO.minigame_count = 0;

    }
    public void QuitGame() {
        Application.Quit ();
    }
}