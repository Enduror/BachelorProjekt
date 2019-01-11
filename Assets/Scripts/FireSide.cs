using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSide : MonoBehaviour {

    public GameObject weaponFire;
    
    
    private void Start()
    {
        weaponFire = GameObject.Find("FireParticles");
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

        }
    }

}
