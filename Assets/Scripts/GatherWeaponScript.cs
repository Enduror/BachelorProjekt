using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherWeaponScript : MonoBehaviour {
    public MessageBord message;
    public GameObject player;

    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollider")
        {
            player.GetComponentInParent<PlayerController>().ActivateWeapon();            
            Destroy(gameObject);

        }
    }
}
