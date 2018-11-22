using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    public GameObject player;
    public Animator anim;
    
   
    public int spikeDamage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("Spike");
            player.GetComponentInParent<PlayerController>().TakeDamage(spikeDamage);            
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }

}
