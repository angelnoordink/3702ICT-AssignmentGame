using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

    [SerializeField] private string Minigame;
    [SerializeField] private GameObject uiElement;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            // Make a UI Appear
            uiElement.SetActive(true);

            // Button press
            if(Input.GetKeyDown(KeyCode.E)) {
                SceneManager.LoadScene(Minigame);
                Debug.Log("E key was pressed.");
            }

            if (Input.GetKeyUp(KeyCode.E)) {
                SceneManager.LoadScene(Minigame);
                Debug.Log("E key was pressed.");
            }
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            uiElement.SetActive(false);
        }
    }
    
}
