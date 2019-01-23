using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    public GameObject player;
    public Animator anim;

    public AchievmentDisplay achievmentDisplay;
    
   
    public int spikeDamage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        try
        {
            achievmentDisplay = GameObject.FindGameObjectWithTag("StepOnTrapsAchievement").GetComponent<AchievmentDisplay>();
        }
        catch
        {

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollider")
        {
            anim.SetTrigger("Spike");
            player.GetComponentInParent<PlayerController>().TakeDamage(spikeDamage);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<AudioSource>().Play();
            if (achievmentDisplay != null)
            {
                achievmentDisplay.SteppedOnSpike();
            }
        }
        
    }

}
