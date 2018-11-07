using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomManager : MonoBehaviour {

    public Transform player;
    public Camera cam;

    public float currentSize;
    public int smallSize;
    public int bigSize;

    public float zoomSpeed;

    float lerpTime = 0.6f;
    float currentLerpTime;
    

    private void Start()
    {
        cam = Camera.main;
        
    }

    public void Update()
    {
        cam.orthographicSize = currentSize;
        if (transform.position.y > player.position.y)
        {
              Zoom(bigSize);
        }
        else
        {
            Zoom(smallSize);
           
        }
    }

    public void Zoom(int targetZoom)
    {
        if (currentSize != targetZoom)
        {
            if (targetZoom > currentSize)
            {
                currentSize += Time.deltaTime;
            }

            if (targetZoom < currentSize)
            {
                currentSize += -(Time.deltaTime);
            }
        }
        
    }







}
