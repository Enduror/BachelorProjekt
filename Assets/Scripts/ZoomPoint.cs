using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPoint : MonoBehaviour {
    public GameObject cam;
    public int zoomTarget;

    public void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.GetComponentInParent<CameraZoomManager>().targetZoom = zoomTarget;
    }
}
