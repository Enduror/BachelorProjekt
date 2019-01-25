using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretFinderScript : MonoBehaviour {

    public AudioManager audiomanager;
    public AchievmentDisplay achievementDisplay;
    
	// Use this for initialization
	void Start () {
        audiomanager = FindObjectOfType<AudioManager>();
        try
        {
            achievementDisplay = GameObject.FindGameObjectWithTag("FindSecretsAchievement").GetComponent<AchievmentDisplay>();
        }
        catch
        {
          
        }
    }	
	

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Collider2D>().enabled = false;
        audiomanager.Play("sound_player_wow");

        if (achievementDisplay != null)
        {
            achievementDisplay.FindSecret();
        }
        
    }
}
