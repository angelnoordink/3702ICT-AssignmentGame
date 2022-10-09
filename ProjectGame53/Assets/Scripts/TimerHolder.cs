using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHolder : MonoBehaviour
{

    public float timer = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // If game is over
            // Stop Timer

    }


}
