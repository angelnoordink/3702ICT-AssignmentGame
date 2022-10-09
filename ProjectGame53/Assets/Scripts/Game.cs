using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField] public EndTimer endTimer;
    [SerializeField] public NameTracking nameTracking;

    void Start() {
        string currentName = nameTracking.name;
        int currentScore = Mathf.RoundToInt(endTimer.timer);

        Highscores.AddNewHighscore(currentName, currentScore);
    }
}
