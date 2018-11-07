using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    public Vector3 distanceVector;
	
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position+distanceVector;
	}
}
