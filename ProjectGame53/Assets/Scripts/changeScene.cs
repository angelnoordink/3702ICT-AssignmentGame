using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

    [SerializeField] private string Minigame;
    [SerializeField] private GameObject uiElement;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")) {
            // Make a UI Appear
            uiElement.SetActive(true);

            // Button press
            // if(Input.GetKeyDown(KeyCode.J)) {
                // SceneManager.LoadScene(Minigame);
                Debug.Log("J key was pressed.");
            // }

            
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            uiElement.SetActive(false);
        }
    }

    private void Update(){

    }
    
}
