using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    [SerializeField] public MiniGameCountSO miniGameCountSO;
    [SerializeField] public NameTracking nameTracking;

    // [SerializeField] public TextMeshProUGUI playerName; 

    private string playerNameString;


    public void LoadLevel (string levelName ) {
        // This will load another scene and takes parameter index of scene or string name
        SceneManager.LoadScene(levelName);
        miniGameCountSO.minigame_count = 0;

    }

    public void ReadStringInput(string s){
        nameTracking.name = s;
        
        Debug.Log(nameTracking.name);

    }


    public void QuitGame() {
        Application.Quit ();
    }
}