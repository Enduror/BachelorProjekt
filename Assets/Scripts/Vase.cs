using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour {
    public bool isBroken;
    public GameObject shadow;
    public GameObject vaseParticle;
    public Animator vaseAnim;
    public AudioManager audioManager;
    public AchievmentDisplay achievmentDisplay;
	// Use this for initialization
	void Start () {
        audioManager = FindObjectOfType<AudioManager>();
        vaseAnim = GetComponent<Animator>();
        try
        {
            achievmentDisplay = GameObject.FindGameObjectWithTag("DestroyVasesAchievement").GetComponent<AchievmentDisplay>();
        }
        catch { }
        if (isBroken == true)
        {
            vaseAnim.Play("BrokenIdle");
            GetComponent<Collider2D>().enabled = false;
            if (shadow != null) { shadow.SetActive(false); }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (isBroken == false && (collision.tag == "PlayerCollider"||collision.tag=="Weapon"))
        {
            if (isBroken == false) { Destroy(Instantiate(vaseParticle, transform.position, Quaternion.identity), 2); }

            DataToSaveScript.VasesDestroyed_SaveValue++;
            GetComponent<Collider2D>().enabled = false;
            vaseAnim.SetTrigger("Shatter");
            gameObject.GetComponent<AudioSource>().Play();
            isBroken = true;
            if (achievmentDisplay != null)
            {
                achievmentDisplay.KillVaseCounter();
            }

            //Destroy(gameObject, 4);
        }
        else if (isBroken == true && collision.tag == "PlayerCollider")
        {
            audioManager.Play("sound_player_steponglas");
            vaseAnim.SetTrigger("Schutt");
        }


        if (shadow != null) { shadow.SetActive(false); }

        

        
    }


}
