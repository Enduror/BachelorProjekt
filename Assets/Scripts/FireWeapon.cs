using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour {
    public GameObject tip;
    public PlayerController playerController;

    public bool isBurning;
	// Use this for initialization
	void Start () {
        playerController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = tip.transform.position;
	}

    public void CheckForWeapon()
    {
        if (playerController.hasWeapon == true && isBurning == true)
        {
            GetComponent<ParticleSystem>().Play();
        }
        else
        {
            GetComponent<ParticleSystem>().Stop();
        }
        
    }
}
