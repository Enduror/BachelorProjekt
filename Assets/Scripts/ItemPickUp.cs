using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    public AudioManager audioManager;
    public AchievmentDisplay achievmentDisplay;

    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        try
        {
            achievmentDisplay = GameObject.FindGameObjectWithTag("CollectAHatAchievement").GetComponent<AchievmentDisplay>();
        }
        catch
        {

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (gameObject.name == "Crown(Clone)" && collision.CompareTag("PlayerCollider"))
        {
            collision.GetComponentInParent<PlayerController>().ActivateCrownMode();
            audioManager.Play("sound_player_wow");
            Destroy(gameObject);
        }
        if (gameObject.name == "StrawHat" && collision.CompareTag("PlayerCollider"))
        {
            collision.GetComponentInParent<PlayerController>().ActivateStrawHatMode();           
            if (achievmentDisplay != null)
            {                
                achievmentDisplay.FoundSecretLevel();
            }
            audioManager.Play("sound_player_wow");
            Destroy(gameObject,0.4f);
        }
        if (gameObject.name == "SunGlases(Clone)" && collision.CompareTag("PlayerCollider"))
        {
            collision.GetComponentInParent<PlayerController>().ActivateSunglases();
            audioManager.Play("sound_player_wow");
            Destroy(gameObject);
        }
        
    }
}
