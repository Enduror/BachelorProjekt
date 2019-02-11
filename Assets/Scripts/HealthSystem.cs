using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {
    public float health;
    public float startHealth;
    public EventController ec;
    public AudioManager audioManager;
    public GameObject healthPickUp;
    public bool finalBossHit;
    public Slider healthBarSlider;

    public AchievmentDisplay achievmentDisplay;

    public GameObject crown;
    public bool alive;


    // Use this for initialization
    void Start()
    {
        alive = true;
        health = startHealth;
        ec = FindObjectOfType<EventController>();
        audioManager = FindObjectOfType<AudioManager>();
        try
        {
            achievmentDisplay = GameObject.FindGameObjectWithTag("NoWeaponAchievement").GetComponent<AchievmentDisplay>();
        }
        catch
        {

        }
        if (healthBarSlider != null)
        {
            healthBarSlider.value = CalculateHealth();
        }

    }


    // Update is called once per frame
    void Update () {

        //Healthbar updater
        

        //deadChecker

        if (health <= 0 && alive)
        {
            DataToSaveScript.EnemiesKilled_SaveValue++;
           
            if (gameObject.tag == "FinalBoss")
            {
                Instantiate(crown, transform.position, transform.rotation);
                if (finalBossHit == false)
                {
                    try
                    {
                        achievmentDisplay.NoWeaponBoss();
                    }
                    catch{ }
                }
                    
            }
            else
            {           
                var rng = Random.Range(0, 40);

                 if (rng <= 1)
                 {
                      if (gameObject != null)
                     {
                         Instantiate(healthPickUp, transform.position, transform.rotation);                    
                     }
                 }
            }
            alive = false;
            Destroy(gameObject);           
        }
    }
    public void TakeDamage(int damage)
    {
        if (gameObject.CompareTag("FinalBoss"))
        {            
            DataToSaveScript.FinalBossHitCounter_SaveValue++;

            if (finalBossHit == true)
            {
                try
                {
                    achievmentDisplay.hitTheBoss = true;
                    achievmentDisplay.NoWeaponBoss();
                }
                catch { }
            }
           
        }
        DataToSaveScript.DamageDealt_SaveValue += damage;
        audioManager.Play("sound_tomato_death");
        health -= damage;
        if (healthBarSlider != null)
        {            
            healthBarSlider.value = CalculateHealth();
        }

    }
    float CalculateHealth()
    {
        return health / startHealth;
    }

    
}
