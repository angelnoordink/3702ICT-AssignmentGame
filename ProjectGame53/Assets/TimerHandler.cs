using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHandler : MonoBehaviour
{
    public float timer = 0;

    void Start(){
        DontDestroyOnLoad(gameObject);
    }

    void Update(){

        timer += Time.deltaTime;
        Debug.Log(timer);
    }
}
