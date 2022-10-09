using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    bool gameHasEnded = false;
    // int lives = 3;
    [SerializeField] private GameObject introDialogue;

    [SerializeField] public MiniGameCountSO miniGameCountSO;

    [SerializeField] public LastPosition lastPosition;

    public GameObject ThirdPersonController;

    void Start(){
        
        if(miniGameCountSO.minigame_count != 0){
            introDialogue.SetActive(false);
            
            ThirdPersonController.transform.position = lastPosition.pos; 

        }
        else if(miniGameCountSO.minigame_count != 0){

            ThirdPersonController.transform.position = new Vector3(5.5f, 0.1f, 10.7f);
        }

    }

    void Update(){
        lastPosition.pos = ThirdPersonController.transform.position;
    }

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
