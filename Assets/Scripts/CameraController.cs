using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    public Vector3 distanceVector;
	
    public void Awake()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position+distanceVector;
	}
}
