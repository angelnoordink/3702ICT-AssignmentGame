using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCountHandler : MonoBehaviour {
    public int count = 0;
    [SerializeField] public MiniGameCountSO miniGameCountSO;


    void Start(){
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        count = miniGameCountSO.minigame_count;
        // Debug.Log("MiniGame count"+miniGameCountSO.minigame_count);
    }
}
