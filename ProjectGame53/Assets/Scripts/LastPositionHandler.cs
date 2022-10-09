using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPositionHandler : MonoBehaviour
{
    public Vector3 last_position;
    [SerializeField] public LastPosition lastPosition;


    void Start(){
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        last_position = lastPosition.pos;
    }
}
