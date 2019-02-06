using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    public int damage = 1;
    public GameObject tomatoBlood;
    public GameObject wallEmiter;

    public Transform tip;
    public Vector2 bloodDirection;
    public Animator anim;
    public AudioManager AudioManager;
    
    

    public AchievmentDisplay achievmentDisplay;

    public void Start()
    {
        try
        {
            achievmentDisplay = GameObject.FindGameObjectWithTag("HitTheWallAchievement").GetComponent<AchievmentDisplay>();
        }
        catch
        {
            
        }
    }

    public void Update()
    {
        if (anim == null)
        {
            anim = Camera.main.GetComponent<Animator>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //anim.SetTrigger("shake");
        if (collision.name == "GroundManager")
        {
            DataToSaveScript.WallHits_SaveValue++;
            try
            {
                anim.SetTrigger("shake");
            }
            catch
            {
                anim = Camera.main.GetComponent<Animator>();
                anim.SetTrigger("shake");
            }
           
            AudioManager.Play("sound_player_hitwall");
            if(achievmentDisplay!=null)
                achievmentDisplay.WallHitCounter();            
            
            
            Destroy(Instantiate(wallEmiter, tip.position, tip.rotation), 10);
        }


        if (collision.GetComponent<Collider2D>().gameObject.layer==LayerMask.NameToLayer("Enemy"))
        {
            anim.SetTrigger("shake");
            if (collision.GetComponentInParent<Transform>().CompareTag("FinalBoss"))
            {                
                collision.GetComponent<HealthSystem>().finalBossHit = true;
            }
            collision.GetComponentInParent<HealthSystem>().TakeDamage(damage);
            Vector3 relativePos = collision.GetComponent<Transform>().position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            Destroy(Instantiate(tomatoBlood, collision.transform.position, rotation), 10);            
        }

       
        
    }
}
