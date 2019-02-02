using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSide : MonoBehaviour {

    public GameObject weaponFire;
    public AchievmentDisplay achievmentDisplay;

    
    
    private void Start()
    {
        weaponFire = GameObject.Find("FireParticles");

        try
        {
            achievmentDisplay = GameObject.FindGameObjectWithTag("HotFork").GetComponent<AchievmentDisplay>();
        }
        catch { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollider")
        {
            collision.GetComponentInParent<PlayerController>().TakeDamage(1);
        }
        if(collision.tag== "Weapon")
        {

            weaponFire.GetComponent<FireWeapon>().isBurning = true;
            weaponFire.GetComponent<FireWeapon>().CheckForWeapon();
            if (achievmentDisplay != null)
            {
                achievmentDisplay.HotFork();
            }

        }
    }

}
