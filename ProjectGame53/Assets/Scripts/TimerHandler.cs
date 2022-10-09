using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerHandler : MonoBehaviour {
    public float timer = 0;
    [SerializeField] public EndTimer endTimer;
    [SerializeField] public TextMeshProUGUI timeText;
    private string timeString;

    void Start(){
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        timer += Time.deltaTime;
        endTimer.timer = timer;
    }
}
