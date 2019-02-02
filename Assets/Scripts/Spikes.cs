using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    public GameObject player;
    public Animator anim;
    public GameObject finalBossBlood;

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
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            
            if (achievmentDisplay != null)
            {
                achievmentDisplay.SteppedOnSpike();
            }
        }
        if (collision.tag == "FinalBoss")
        {
            anim.SetTrigger("Spike");
            collision.GetComponent<HealthSystem>().TakeDamage(25);
            Instantiate(finalBossBlood, collision.transform.position, Quaternion.identity);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<AudioSource>().Play();
        }
        
    }

}
