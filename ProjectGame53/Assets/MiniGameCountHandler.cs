using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameCountHandler : MonoBehaviour {
    public int count = 0;
    [SerializeField] public MiniGameCountSO miniGameCountSO;


    void Start(){
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        count = miniGameCountSO.minigame_count;
    }
}
