using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    public GameObject player;
   
    public int spikeDamage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponentInParent<PlayerController>().TakeDamage(spikeDamage);            
        }
    }

}
