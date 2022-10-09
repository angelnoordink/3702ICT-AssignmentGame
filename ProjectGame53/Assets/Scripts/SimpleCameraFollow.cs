using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField] private Vector3 offset = new Vector3(0,10,-15);
    private Vector3 newCamPos = Vector3.zero;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        newCamPos = playerTransform.position + offset;
        transform.position = newCamPos;
        transform.LookAt(playerTransform);
    }
}
