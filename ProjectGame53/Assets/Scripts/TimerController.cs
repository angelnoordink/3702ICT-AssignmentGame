using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour {
    public static TimerController instance;

    [SerializeField] TextMeshProUGUI timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        timeCounter.text = "Time Elapsed: 00:00.00";
        timerGoing = false;
    }

    private void BeginTimer() {  
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    private void EndTimer() {  
        timerGoing = false;
    }


    private IEnumerator UpdateTimer() {
        while (timerGoing){
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time Elapsed: " + timePlaying.ToString("mm':'ss':'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
