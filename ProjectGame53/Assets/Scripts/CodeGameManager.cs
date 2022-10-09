using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CodeGameManager : MonoBehaviour
{
    [SerializeField] private string Game;
    public List<Button> buttons;
    public List<Button> shuffledButtons;
    int counter = 0;

    public MiniGameCountSO miniGameCountSo;


    void Start()
    {
        RestartTheGame();
    }

    public void RestartTheGame(){
        counter = 0;
        shuffledButtons = buttons.OrderBy(a => Random.Range(0,100)).ToList(); // Shuffle button numbers

        for(int i = 1; i < 11; i++){
            shuffledButtons[i - 1].GetComponentInChildren<Text>().text = i.ToString(); 
            shuffledButtons[i - 1].interactable = true; // Can press button 
            shuffledButtons[i - 1].image.color = new Color32(128, 128, 128, 255); // Set default colour to grey

        }

    }


    public void pressButton(Button button){
        if(int.Parse(button.GetComponentInChildren<Text>().text) - 1 == counter){
            counter++;
            button.interactable = false; // Cant re-press button 
            button.image.color = Color.green; // Change colour to green

            if(counter==10){
                StartCoroutine(presentResult(true));

            }

        } else {
            StartCoroutine(presentResult(false));

        }
    }

    public IEnumerator presentResult(bool win){

        if(!win)
        {
            foreach(var button in shuffledButtons){
                // On loss change buttons to red and make buttons briefly unable to be pressed
                button.image.color = Color.red; 
                button.interactable = false;
            }
            // If fail wait 2 seconds then restart game
            yield return new WaitForSeconds(2f);
            RestartTheGame();

        } else {
            // Change the scene if win = true 
            miniGameCountSo.minigame_count += 1;
            SceneManager.LoadSceneAsync("Library");

        }


    }

}
