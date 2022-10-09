using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Highscores : MonoBehaviour {
    const string privateCode = "hwtPvQ3ea0igmYQNrnGoXAIZJ7OqeRDE6FnxAp4sR-tA";
    const string publicCode = "6342e1548f40bc0fe89b1046";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    static Highscores instance;
    DisplayHighscores highscoresDisplay;


    void Awake(){

        // DownloadHighscores();
        instance = this;

        highscoresDisplay = GetComponent<DisplayHighscores> ();
    }

    public static void AddNewHighscore(string username, int score) {
        instance.StartCoroutine(instance.UploadNewHighScore(username,score));
    }

    IEnumerator UploadNewHighScore(string username, int score) {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error)) {
            Debug.Log("Upload Successful");
            DownloadHighscores();
        } else {
            Debug.Log("Error Uploading: " + www.error);
        }
    }

    public void DownloadHighscores() {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase() {
        WWW www = new WWW(webURL + privateCode + "/pipe-score-asc/");
        yield return www;

        if (string.IsNullOrEmpty(www.error)) {
            FormatHighscores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
        } else {
            Debug.Log("Error Uploading: " + www.error);
        }
    }

    void FormatHighscores(string textStream){
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        for (int i = 0; i < entries.Length; i ++) {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username,score);
            // print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }
}


public struct Highscore //Creates place to store the variables for the name and score of each player
{
    public string username;
    public int score;

    public Highscore(string _username, int _score) {
        username = _username;
        score = _score;
    }
}