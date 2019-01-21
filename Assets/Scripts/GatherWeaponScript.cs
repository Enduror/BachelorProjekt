using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherWeaponScript : MonoBehaviour {
    public MessageBord message;
    public GameObject player;
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollider")
        {
            audioManager.Play("sound_player_wow");            
            player.GetComponentInParent<PlayerController>().ActivateWeapon();            
            Destroy(gameObject);


        }
    }
}
