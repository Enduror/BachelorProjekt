using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomManager : MonoBehaviour
{

    public GameObject player;
    public Camera cam;
    public int targetZoom;
    public float currentSize;
    public int startSize;


    public bool enteredFirst;

    private void Start()
    {
        currentSize = startSize;
        targetZoom = startSize;
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");       
    }

    public void Update()
    {
        Zoom(targetZoom);
    }

    public void Zoom(int pTargetZoom)
    {
        if (currentSize != pTargetZoom)
        {
            if (pTargetZoom > currentSize)
            {
                currentSize += Time.deltaTime+0.05f;
            }

            if (pTargetZoom < currentSize)
            {
                currentSize += -(Time.deltaTime+0.05f);
            }
            cam.orthographicSize = currentSize;
        }
    }
}







