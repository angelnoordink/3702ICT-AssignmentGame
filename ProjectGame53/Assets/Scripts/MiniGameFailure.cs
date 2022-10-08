using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MiniGameFailure : MonoBehaviour
{
    
    
     public void LoadLevel (string levelName ) {
        // This will load another scene and takes parameter index of scene or string name
        Debug.Log("HIT");
        SceneManager.LoadSceneAsync(levelName);
    }
    public void QuitGame() {
        Application.Quit ();
    }
}
