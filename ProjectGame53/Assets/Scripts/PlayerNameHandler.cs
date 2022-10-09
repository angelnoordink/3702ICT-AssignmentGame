using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameHandler : MonoBehaviour {
    public string name = "";
    [SerializeField] public NameTracking nameTracking;


    void Start(){
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        name = nameTracking.name;
    }
}
