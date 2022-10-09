using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    [SerializeField] public MiniGameCountSO miniGameCountSO;
    [SerializeField] public NameTracking nameTracking;
    [SerializeField] public bool fromMainMenu;

    public void LoadLevel (string levelName) {
        // This will load another scene and takes parameter index of scene or string name
        SceneManager.LoadScene(levelName);
        if (fromMainMenu){
            miniGameCountSO.minigame_count = 0;
        }
    }

    public void ReadStringInput(string s){
        nameTracking.name = s;
    }


    public void QuitGame() {
        Application.Quit ();
    }
}