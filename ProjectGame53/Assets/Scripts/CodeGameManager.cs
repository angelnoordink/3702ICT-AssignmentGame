using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CodeGameManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip _musicClip;
    [SerializeField]
    private AudioClip _completeClip;
    [SerializeField]
    private AudioClip _failClip;
    private AudioSource _audioSource;

    [SerializeField] private string Game;
    public List<Button> buttons;
    public List<Button> shuffledButtons;
    int counter = 0;

    [SerializeField]
    public MiniGameCountSO miniGameCountSO;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _musicClip;
        _audioSource.Play();
        RestartTheGame();
    }

    public void RestartTheGame(){
         _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _musicClip;
        _audioSource.Play();
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
            // RestartTheGame();
            StartCoroutine(fail());


        } else {
            // Change the scene if win = true 
            miniGameCountSO.minigame_count += 1;
            StartCoroutine(success());

        }

    }



        IEnumerator success(){
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _completeClip;
        _audioSource.Play();
        yield return new WaitWhile (()=>_audioSource.isPlaying);
        SceneManager.LoadSceneAsync("SuccessScene");
    }

      IEnumerator fail(){
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _failClip;
        _audioSource.Play();
        yield return new WaitWhile (()=>_audioSource.isPlaying);
        RestartTheGame();
    }




    void Update()
    {
        
    }
}
