using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHandler : MonoBehaviour {
    public float timer = 0;
    [SerializeField] public EndTimer endTimer;


    void Start(){
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        timer += Time.deltaTime;
        endTimer.timer = timer;
        // Debug.Log(endTimer.timer);
    }
}
