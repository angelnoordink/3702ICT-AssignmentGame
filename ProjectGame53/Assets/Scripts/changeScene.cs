using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
    [SerializeField] private string Minigame;
    [SerializeField] private GameObject uiElement;
    private bool EnteredCollider = false;
    private string CurrentMinigame;

    [SerializeField] public LastPosition lastPosition;

    public GameObject ThirdPersonController;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")) {
            // Make a UI Appear
            uiElement.SetActive(true);
            EnteredCollider = true;
            CurrentMinigame = Minigame;
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
            lastPosition.pos = ThirdPersonController.transform.position;
            if(lastPosition.pos == ThirdPersonController.transform.position){
                SceneManager.LoadScene(CurrentMinigame, LoadSceneMode.Single);
                Debug.Log("J key was pressed.");
            }

        }
    }
    
}
