using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    bool gameHasEnded = false;
    // int lives = 3;

    [SerializeField] public MiniGameCountSO miniGameCountSO;
    [SerializeField] public LastPosition lastPosition;
    [SerializeField] public EndTimer endTimer;

    public GameObject timerHandler;
    public GameObject miniGameCountHandler;
    public GameObject lastPositionHandler;
    public GameObject ThirdPersonController;

    [SerializeField] private GameObject introDialogue;
    [SerializeField] private GameObject librarianCompleteDialogueBox;
    [SerializeField] private GameObject quizGameCompleteDialogueBox;
    [SerializeField] private GameObject wireGameCompleteDialogueBox;

    [SerializeField] private GameObject librarianCollider;
    [SerializeField] private GameObject quizCollider;
    [SerializeField] private GameObject wiresCollider;

    [SerializeField] private GameObject librarianParticles;
    [SerializeField] private GameObject quizParticles;
    [SerializeField] private GameObject wiresParticles;

    public int count = 0;
    [SerializeField] public Mask keysMask;

    public float timer = 0;
    [SerializeField] public TextMeshProUGUI timeText;
    private string timeString;

    void Start(){
        miniGameCountSO.minigame_count = GameObject.Find("MiniGameCountHandler").GetComponent<MiniGameCountHandler>().count;
        lastPosition.pos = GameObject.Find("LastPositionHandler").GetComponent<LastPositionHandler>().last_position;

        if(miniGameCountSO.minigame_count == 0){
            introDialogue.SetActive(true);

            ThirdPersonController.transform.position = new Vector3(5.5f, 0.1f, 10.7f);

            ShowImage();
        }
        else if(miniGameCountSO.minigame_count == 1){
            librarianCompleteDialogueBox.SetActive(true);

            timerHandler.SetActive(false);
            miniGameCountHandler.SetActive(false);
            lastPositionHandler.SetActive(false);

            librarianCollider.SetActive(false);
            librarianParticles.SetActive(false);

            quizCollider.SetActive(true);
            quizParticles.SetActive(true);

            ShowImage();

            ThirdPersonController.transform.position = lastPosition.pos; 
        }
        else if(miniGameCountSO.minigame_count == 2){
            quizGameCompleteDialogueBox.SetActive(true);

            timerHandler.SetActive(false);
            miniGameCountHandler.SetActive(false);
            lastPositionHandler.SetActive(false);

            quizCollider.SetActive(false);
            quizParticles.SetActive(false);

            wiresCollider.SetActive(true);
            wiresParticles.SetActive(true);

            ShowImage();
            
            ThirdPersonController.transform.position = lastPosition.pos; 
        }
        else if(miniGameCountSO.minigame_count == 3){
            wireGameCompleteDialogueBox.SetActive(true);

            timerHandler.SetActive(false);
            miniGameCountHandler.SetActive(false);
            lastPositionHandler.SetActive(false);

            wiresCollider.SetActive(false);
            wiresParticles.SetActive(false);

            ShowImage();
            
            ThirdPersonController.transform.position = lastPosition.pos; 

            endTimer.timer = GameObject.Find("TimerHandler").GetComponent<TimerHandler>().timer;
            if(endTimer.timer > 0){
                SceneManager.LoadScene("WinOutcome");
            }
        }

    }

    void Update(){
        lastPosition.pos = ThirdPersonController.transform.position;
        ShowTimer();
    }

    public void EndGame() {
        // Debug.Log(lives);
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Debug.Log("Total Time: "+endTimer.timer);
            SceneManager.LoadSceneAsync("LoseOutcome");
            // Restart();
        }
    }

    void Restart(){
        // if (introDialogue.activeSelf){
        //     introDialogue.SetActive(false);
        // 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowImage(){
        count = miniGameCountSO.minigame_count;
        RectTransform rectTransform = keysMask.GetComponent<RectTransform>();

        float k_height = rectTransform.rect.height;
		float k_width = rectTransform.rect.width;
        float updated_width = ((float)count / 3) * k_width;
		
        rectTransform.sizeDelta = new Vector2(updated_width, k_height);
    }

    public void ShowTimer(){
        endTimer.timer = GameObject.Find("TimerHandler").GetComponent<TimerHandler>().timer;

        var duration = TimeSpan.FromSeconds(endTimer.timer);
        string timeString = duration.Minutes.ToString() + ":" + duration.Seconds.ToString();
        timeText.text = "Elapsed time: " + timeString;
    }


}
