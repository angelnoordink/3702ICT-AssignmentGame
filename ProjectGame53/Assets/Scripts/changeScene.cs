using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

    [SerializeField] private string Minigame;
    [SerializeField] private GameObject uiElement;
    private bool EnteredCollider = false;
    private string CurrentMinigame;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")) {
            // Make a UI Appear
            uiElement.SetActive(true);
            EnteredCollider = true;
            CurrentMinigame = Minigame;

            // SceneManager.LoadScene(Minigame);

            // Button press
            // if(Input.GetKeyDown(KeyCode.J)) {
            //     SceneManager.LoadScene(Minigame);
            //     Debug.Log("J key was pressed.");
            // }
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            uiElement.SetActive(false);
            EnteredCollider = false;
        }
    }

    private void Update(){
        if (EnteredCollider == true && Input.GetKeyDown("j")) {
            Debug.Log(CurrentMinigame);
            SceneManager.LoadScene(CurrentMinigame, LoadSceneMode.Single);
            Debug.Log("J key was pressed.");
        }
    }
    
}
