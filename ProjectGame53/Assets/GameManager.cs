using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    bool gameHasEnded = false;
    // int lives = 3;
    [SerializeField] private GameObject introDialogue;

    
    public void EndGame() {
        // Debug.Log(lives);
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Debug.Log("Game Over");
            SceneManager.LoadSceneAsync("LoseOutcome");
            // Restart();
        }
    }

    void Restart(){
        // if (introDialogue.activeSelf){
        //     introDialogue.SetActive(false);
        // }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
