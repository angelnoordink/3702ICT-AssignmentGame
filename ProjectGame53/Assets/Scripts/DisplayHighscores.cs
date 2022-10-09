using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DisplayHighscores : MonoBehaviour {
    public TextMeshProUGUI[] highscoreText;
    Highscores highscoreManager;
    [SerializeField] public NameTracking nameTracking;
    
    void Start() {
        
        for (int i = 0; i < highscoreText.Length; i ++) {
            highscoreText[i].text = i+1 + ". Fetching...";
        }

        highscoreManager = GetComponent<Highscores> ();

        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoresList) {
        for (int i = 0; i < highscoreText.Length; i ++) {
            highscoreText[i].text = i + 1 + ". ";
            if (highscoresList.Length > i) {
                if (highscoresList[i].username == nameTracking.name){
                    highscoreText[i].text += highscoresList[i].username + " - " + highscoresList[i].score + " (Current Player)";
                } else {
                    highscoreText[i].text += highscoresList[i].username + " - " + highscoresList[i].score;
                }
            }
        }
    }

    IEnumerator RefreshHighscores() {
        while(true) {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }

}
